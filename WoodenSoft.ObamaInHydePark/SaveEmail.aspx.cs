using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class SaveEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Request["email"]))
            {
                Session["email"] = StringHelper.RemovePossibleXSS(Request["email"]);
            }
        }
    }
}