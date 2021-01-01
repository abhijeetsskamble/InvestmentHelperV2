using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvestmentHelperV2
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var adminEmail = txtAdmEmail.Text;
            var adminPwd = txtAdmPwd.Text;

            if (adminEmail == "K@123.com" && adminPwd == "123@")
            {
                SiteMaster.LoggedIn = true;
                Response.Redirect("AdminControl.aspx");
            }
            else
            {
                this.PutMessage("Admin user invalid");
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