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
    public partial class CustomerControl : System.Web.UI.Page
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["IHConnectionString"].ConnectionString;

        private int _customerId;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get customer info
            if (Request.Cookies["CustomerEmail"] != null)
            {
                txtEmail.Text = Request.Cookies["CustomerEmail"].Value.ToString();
            }
            this.GetCustomerDetails(txtEmail.Text);

            // Don't want to call this every time
            if (!Page.IsPostBack)
            {
                this.RefreshData();
            }
        }

        private void RefreshData()
        {
            // Get investment info
            var isDataPresent = this.IsInvestmentDataPresent();

            if (!isDataPresent)
            {
                // If investment info is empty, add investment info
                lblStatus.Visible = true;

                lblAlreadyFilled.Visible = false;
                btnUpdateExisting.Visible = false;
                lblUpdateExisting.Visible = false;
            }
            else
            {
                lblStatus.Visible = false;

                lblAlreadyFilled.Visible = true;
                btnUpdateExisting.Visible = true;
                lblUpdateExisting.Visible = true;
            }
        }

        private void GetCustomerDetails(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string query = string.Format("SELECT TOP 1 C.[Name], PF.Mobile, PF.[Address], C.Id FROM Customer C JOIN  PersonalInfo PF ON C.Id = PF.CustomerId WHERE Email = '{0}'", email);
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            txtName.Text = reader[0].ToString();
                            txtMobile.Text = reader[1].ToString();
                            txtAddress.Text = reader[2].ToString();
                            _customerId = Convert.ToInt32(reader[3].ToString());
                        }

                    }
                }
            }
            catch (Exception e)
            {
                
            }
        }

        private bool IsInvestmentDataPresent()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string query = string.Format("SELECT TOP 1 * FROM InvestmentInfo WHERE CustomerId = {0}", _customerId);
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var dob = Convert.ToDateTime(reader[1].ToString());
                            txtDOB.Text = dob.ToString("yyyy-MM-dd");

                            txtAnnualIncome.Text = reader[2].ToString();
                            txtOtherIncome.Text = reader[3].ToString();
                            txtRentAmount.Text = reader[4].ToString();

                            // set EPFo
                            var efValues = reader[5].ToString();
                            this.SetEfoValues(efValues);

                            // set nps
                            if (reader[5].ToString().ToLower().Equals("true"))
                            {
                                rdNps.SelectedIndex = 1;
                            }

                            // Set risk
                            dpRisk.SelectedValue = reader[7].ToString();

                            this.DisableFields();
                            return true;
                        }
                        return false;

                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void DisableFields()
        {
            txtDOB.ReadOnly = true;
            txtAnnualIncome.ReadOnly = true;
            txtOtherIncome.ReadOnly = true;
            txtRentAmount.ReadOnly = true;

            cbPF.Enabled = false;
            rdNps.Enabled = false;
            dpRisk.Enabled = false;

            btnUpdateInvestmentInfo.Visible = false;
        }

        private void EnableFields()
        {
            txtDOB.ReadOnly = false;
            txtAnnualIncome.ReadOnly = false;
            txtOtherIncome.ReadOnly = false;
            txtRentAmount.ReadOnly = false;

            cbPF.Enabled = true;
            rdNps.Enabled = true;
            dpRisk.Enabled = true;

            btnUpdateInvestmentInfo.Visible = true;
        }


        private void SetEfoValues(string valueinDb)
        {

            var values = valueinDb.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < cbPF.Items.Count ; j++)
                {
                    if (cbPF.Items[j].Value == values[i])
                    {
                        cbPF.Items[j].Selected = true;
                    }
                }                
            }            
        }

        protected void btnUpdateInvestmentInfo_Click(object sender, EventArgs e)
        {
            InvestmentInfo cInfo = new InvestmentInfo();
            cInfo.CustomerId = _customerId;
            cInfo.DOB = txtDOB.Text;
            cInfo.Income = Convert.ToDouble(txtAnnualIncome.Text);
            cInfo.OtherIncome = Convert.ToDouble(txtOtherIncome.Text);
            cInfo.Rent = Convert.ToDouble(txtRentAmount.Text);

            cInfo.EF = string.Join(",", cbPF.Items.Cast<ListItem>()
                        .Where(li => li.Selected)
                        .ToList());

            cInfo.NPS = rdNps.SelectedIndex == 1;
            cInfo.Risk = dpRisk.SelectedValue;

            this.EnterInvestmentInfo(cInfo);

            // Reload the page data
            this.RefreshData();

        }

        private void EnterInvestmentInfo(InvestmentInfo info)
        {
            try
            {
                int nps = 0;
                if(info.NPS)
                {
                    nps = 1;
                }
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string query = lblAlreadyFilled.Visible 

                        ? string.Format("UPDATE InvestmentInfo SET DOB = '{1}',Income = {2}, OtherIncome = {3}, Rent = {4}, EF = '{5}', NPS = {6}, Risk = '{7}' WHERE CustomerId = {0}",
                        info.CustomerId, info.DOB, info.Income, info.OtherIncome, info.Rent, info.EF, nps, info.Risk)
                    
                        : string.Format("INSERT INTO InvestmentInfo VALUES( {0}, '{1}', {2}, {3}, {4}, '{5}', {6}, '{7}')",
                        info.CustomerId, info.DOB, info.Income, info.OtherIncome, info.Rent, info.EF, nps, info.Risk);
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        protected void btnUpdateExisting_Click(object sender, EventArgs e)
        {
            this.EnableFields();
        }
    }
}