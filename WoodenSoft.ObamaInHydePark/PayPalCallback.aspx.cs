using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class PayPalCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var str = Request.Params.AllKeys.Aggregate("", (current, key) => current + (key + ":" + Request[key]));
            var emailer = new Emailer(ConfigurationManager.AppSettings["SmtpServer"], "", "", 25);
            emailer.SendHtmlEmail(ConfigurationManager.AppSettings["FromEmail"], "woodensdinc@gmail.com", "Obama in hyde park", str);
            if (string.Compare(Request["payment_status"], "Completed", true, CultureInfo.CurrentCulture) != 0 && !string.IsNullOrEmpty(Request["invoice"])) 
                return;
            try
            {
                var orderNum = Guid.NewGuid().ToString();
                var order = new Order
                                {
                                    Email = Session["Email"].ToString(),
                                    HasBeenProcessed = 0,
                                    OrderNumber = orderNum
                                };
                var order2 = new Order
                                 {
                                     Email = Session["Email"].ToString(),
                                     HasBeenProcessed = 2,
                                     OrderNumber = orderNum
                                 };
                var orderRepo = new OrderRepository();
                orderRepo.PlaceOrder(order);
                orderRepo.PlaceOrder(order2);
                EmailerFactory.SendDownloadLink(order, order2);
                litMessage.Text = "The Obama Tour Link Was Sent To Your Email! Click The Link To Download It!";
            }
            catch(Exception ex)
            {
                litMessage.Text = "An Error Occurred Please Contact Us Error: " + ex;
            }
        }
    }
}