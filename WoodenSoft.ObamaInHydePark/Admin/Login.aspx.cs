using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoodenSoft.ObamaInHydePark.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var isTosh = txtPassword.Text == ConfigurationManager.AppSettings["AdminPassword"] &&
                         txtUsername.Text == ConfigurationManager.AppSettings["AdminUsername"];
            if(isTosh)
            {
                Session["IsTosh"] = isTosh;
                Response.Redirect("/Admin/AdminPanel.aspx", true);
                return;
            }
            lblError.Text = "<strong>Failed To log Into System your username or password was incorrect!</strong>";
        }
    }
}