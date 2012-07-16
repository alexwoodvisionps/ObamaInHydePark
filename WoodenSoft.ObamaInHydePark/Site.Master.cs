using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var settings = new SettingsRepository().GetSettings();
            if (settings != null)
            {
                companyLogo.ImageUrl = settings.LogoUrl;
            }
           
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            var emailer = EmailerFactory.NewDefaultInstance();
            if(string.IsNullOrEmpty(txtSubscriberEmail.Text) || !StringHelper.IsValidEmail(txtSubscriberEmail.Text))
            {
                return;
            }
            emailer.SendHtmlEmail(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromEmail"], "New Subscriber", "The new subscriber's email address is " + txtSubscriberEmail.Text);
        }

    }
}