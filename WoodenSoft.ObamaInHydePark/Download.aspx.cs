using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;
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
                if(_orderRepo.ValidateOrder(Request["OrderNumber"]))
                {
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"obamainhydeparktour.zip\"");
                    Response.TransmitFile("/Tour/Obama.zip");
                    Response.End();
                }
            }
        }
    }
}