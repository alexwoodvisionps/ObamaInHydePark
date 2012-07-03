using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class BuyNow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&hosted_button_id=95FHU2RTMYTTC");
        }
    }
}