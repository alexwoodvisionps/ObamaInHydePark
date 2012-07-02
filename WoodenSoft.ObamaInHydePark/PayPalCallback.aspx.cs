using System;
using System.Collections.Generic;
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
            if (string.Compare(Request["payment_status"], "VERIFIED", true, CultureInfo.CurrentCulture) != 0) 
                return;
            try
            {
                var order = new Order
                                {
                                    Email = Session["Email"].ToString(),
                                    HasBeenProcessed = 0,
                                    OrderNumber = Guid.NewGuid().ToString()
                                };
                var orderRepo = new OrderRepository();
                orderRepo.PlaceOrder(order);
                EmailerFactory.SendDownloadLink(order);
                litMessage.Text = "The Obama Tour Link Was Sent To Your Email! Click It To Download It!";
            }
            catch(Exception ex)
            {
                litMessage.Text = "An Error Occurred Please Contact Us Error: " + ex;
            }
        }
    }
}