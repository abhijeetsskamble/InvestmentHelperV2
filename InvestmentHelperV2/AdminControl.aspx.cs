using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace InvestmentHelperV2
{
    public partial class AdminControl : System.Web.UI.Page
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["IHConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            gdCustomerInfo.DataSource = this.GetCustomerDetails();
            gdCustomerInfo.DataBind();
        }

        private DataTable GetCustomerDetails()
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT C.Id, C.[Name], PF.Mobile, PF.Email, PF.[Address] FROM Customer C JOIN  PersonalInfo PF ON C.Id = PF.CustomerId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        conn.Open();
                        da.Fill(dataTable);

                        return dataTable;

                    }
                }
            }            
            catch(Exception e)
            {
                lblError.Visible = true;
                lblError.Text = "Error while fetching records, please contact developers." ;
                return null;
            }
        }

        protected void gdCustomerInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = gdCustomerInfo.SelectedRow.Cells[1].Text;
            txtName.Text = gdCustomerInfo.SelectedRow.Cells[2].Text;
            txtMobile.Text = gdCustomerInfo.SelectedRow.Cells[3].Text;
            txtEmail.Text = gdCustomerInfo.SelectedRow.Cells[4].Text;
            txtAddress.Text = gdCustomerInfo.SelectedRow.Cells[5].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var customerDetails = new Customer();
            customerDetails.Name = txtName.Text;
            customerDetails.Email = txtEmail.Text;
            customerDetails.Mobile = txtMobile.Text;
            customerDetails.Address = txtAddress.Text;
            customerDetails.Password = "";
            customerDetails.ConfirmPassword = "";
            customerDetails.CustomerId = Convert.ToInt32(txtId.Text);

            Register reg = new Register();
            var result = reg.SetCustomerProperties(customerDetails, false);

            if (result)
            {
                this.UpdateRecords(customerDetails);

                // refresh page to update record
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                var message = "Please enter valid data.";
                this.PutMessage(message);
            }
        }

        private void UpdateRecords(Customer cust)
        {
            try
            {
                this.UpdatePersonalInfo(cust);
            }
            catch (Exception e)
            {
                this.PutMessage(string.Format("Error while updating customer: {0}", e.Message));
            }
        }

        private int UpdatePersonalInfo(Customer cust)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = string.Format("UPDATE PersonalInfo SET Mobile = '{0}', Email = '{1}', [Address] = '{2}' WHERE CustomerId = {3}", 
                    cust.Mobile, cust.Email, cust.Address, cust.CustomerId);

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        private void PutMessage(string message)
        {
            string script = string.Format("alert(\"{0}\");", message);
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);
        }
    }
}