using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvestmentHelperV2
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public static bool LoggedIn = false;

        public void Page_Load(object sender, EventArgs e)
        {
            if (LoggedIn)
            {
                HeadLoginView.Visible = false;
                LogoutView.Visible = true;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            HeadLoginView.Visible = true;
            LogoutView.Visible = false;
            LoggedIn = false;
            Response.Redirect("Default.aspx");
        }
    }
}
