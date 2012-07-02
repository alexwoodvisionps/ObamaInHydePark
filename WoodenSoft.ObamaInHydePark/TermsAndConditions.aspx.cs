using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class TermsAndConditions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            var settings = new SettingsRepository().GetSettings();
            if (settings == null)
                return;
            txtTerms.Text = settings.Terms;
        }
    }
}