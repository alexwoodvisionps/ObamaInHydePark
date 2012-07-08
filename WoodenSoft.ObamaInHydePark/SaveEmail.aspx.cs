using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class SaveEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Request["email"]))
            {
                Session["email"] = StringHelper.RemovePossibleXSS(Request["email"]);
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
                    orderRepo.PlaceOrder(order, ProcessedValue.Download);
                    orderRepo.PlaceOrder(order2, ProcessedValue.Map);
                    EmailerFactory.NewDefaultInstance().SendHtmlEmail(ConfigurationManager.AppSettings["FromEmail"],
                                  ConfigurationManager.AppSettings["ToshEmail"],
                                  "Order Placed Please Verify And Ship Via The Control Panel",
                                  "Please Go To obamainhydepark.com/Admin/AdminPanel.aspx And Verify & Approve The Order Of Order Id = " +
                                  order.OrderNumber);
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}