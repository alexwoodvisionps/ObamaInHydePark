using System;

namespace WoodenSoft.ObamaInHydePark.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var isTosh = Session["IsTosh"] != null && Session["IsTosh"].ToString() == "True";
            if(!isTosh)
                Response.Redirect("/Admin/Login.aspx");
        }
    }
}