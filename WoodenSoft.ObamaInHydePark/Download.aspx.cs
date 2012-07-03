using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class Download : System.Web.UI.Page
    {
        private readonly IOrderRepository _orderRepo;
        public Download()
        {
            _orderRepo = new OrderRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Request["OrderNumber"]))
            {
                if(_orderRepo.ValidateOrder(Request["OrderNumber"], ProcessedValue.Download))
                {
                    var order1 =
                        _orderRepo.GetAllOrders().First(
                            x =>
                            x.OrderNumber == Request["OrderNumber"] && x.HasBeenProcessed == (int)ProcessedValue.Download);
                    _orderRepo.FulFillOrder(order1);
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"obamainhydeparktour.zip\"");
                    Response.TransmitFile("/Tour/Obama.zip");
                    Response.End();
                    return;
                }
            }
            
            var settings = new SettingsRepository().GetSettings();
            if(settings != null)
            {
                if(!string.IsNullOrEmpty(settings.ITunesUrl))
                {
                    litItunes.Text = "<a href='" + settings.ITunesUrl +
                                     "'>Click Here To Download The ITunes Podcast Version</a>";
                }
            }
        }
    }
}