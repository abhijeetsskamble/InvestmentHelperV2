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
    public partial class _Default : System.Web.UI.Page
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["IHConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text;
            var pwd = txtPwd.Text;

            if (this.VerifyLogin(email, pwd))
            {
                SiteMaster.LoggedIn = true;

                HttpCookie Cookie = new HttpCookie("CustomerEmail");
                Cookie.Value = email;
                Cookie.Expires = DateTime.Now.AddHours(2);
                Response.Cookies.Add(Cookie);
                Response.Redirect("CustomerControl.aspx");  
            }
            else
                this.PutMessage("Failure");
        }

        private bool VerifyLogin(string email, string pwd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    string query =
                    string.Format("SELECT C.Id FROM Customer C " +
                        "JOIN PersonalInfo P ON C.Id = P.CustomerId " +
                        "JOIN LoginDetails L ON C.Id = L.CustomerId " +

                        "WHERE P.Email = '{0}' " +
                        "AND L.[Password] = '{1}'", email, pwd);

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        int result;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out result);
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        private void PutMessage(string message)
        {
            string script = string.Format("alert(\"{0}\");", message);
            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);
        }
    }
}