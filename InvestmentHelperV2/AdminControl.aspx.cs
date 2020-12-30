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
                    string query = "SELECT C.[Name], PF.Mobile, PF.Email, PF.[Address] FROM Customer C JOIN  PersonalInfo PF ON C.Id = PF.CustomerId";
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
    }
}