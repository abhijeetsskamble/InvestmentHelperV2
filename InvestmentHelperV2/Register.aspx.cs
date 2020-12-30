using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace InvestmentHelperV2
{
    public partial class Register : System.Web.UI.Page
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["IHConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var customerDetails = new Customer();
            var result = SetCustomerProperties(customerDetails);

            if (result)
            {
                this.AddCustomerToDb(customerDetails);
                Response.Redirect("Default.aspx");
            }
            else
            {
                var message = "Invalid Data";
                this.PutMessage(message);
            }
        }

         private bool SetCustomerProperties(Customer customerDetails)
        {
            bool validFields = true;
            customerDetails.Name = txtName.Text;
            customerDetails.Email = txtEmail.Text;

            customerDetails.Mobile = txtMobile.Text;
            if (customerDetails.Mobile.Length != 10)
            {
                this.RaiseIssue(lblMobile, "Invalid mobile number");
                validFields = false;
            }

            customerDetails.Address = txtAddress.Text;
            if (string.IsNullOrEmpty(customerDetails.Address) || customerDetails.Address.Length < 5)
            {
                this.RaiseIssue(lblAddress, "Address is empty or too small");
                validFields = false;
            }

            customerDetails.Password = txtPwd.Text;
            if (customerDetails.Password != txtConPwd.Text)
            {
                this.RaiseIssue(lblConPwd, "Password do not match");
                validFields = false;
            }

            return validFields;
        }

        private void RaiseIssue(Label errorLabel, string error)
        {
            // Set error visibility to true
            lblErrors.Text = lblErrors.Text + "<br />" + error;
            lblErrors.Visible = true;

            lblErrors.BackColor = System.Drawing.Color.Orange;

            // set label to be displayed as warning
            errorLabel.BackColor = System.Drawing.Color.Yellow;
        }

        private void AddCustomerToDb(Customer cust)
        {
            // Check if the mobile number already exist in the DB 

            // If exist then warn user that he/she is already registered 

            // If not added, then add the new entried to three tables 
            this.RegisterNewUser(cust);
        }

        private void RegisterNewUser(Customer cust)
        {
            try
            {
                this.PopulateCustomer(cust);
                this.PopulateLoginDetails(cust);
                this.PopulatePersonalInfo(cust);
            }
            catch (Exception e)
            {
                this.PutMessage(string.Format("Error while registering: {0}", e.Message));
            }
        }

        private void PopulatePersonalInfo(Customer cust)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = string.Format("INSERT INTO PersonalInfo VALUES({0}, '{1}'," +
                    "'{2}', '{3}')", cust.CustomerId, cust.Mobile, cust.Email, cust.Address);
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void PopulateLoginDetails(Customer cust)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = string.Format("INSERT INTO LoginDetails VALUES({0}, '{1}')", cust.CustomerId, cust.Password);
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void PopulateCustomer(Customer cust)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = string.Format("INSERT INTO Customer VALUES('{0}'); SELECT SCOPE_IDENTITY()", cust.Name);
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    int result;
                    int.TryParse(cmd.ExecuteScalar().ToString(), out result);
                    cust.CustomerId = result;
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