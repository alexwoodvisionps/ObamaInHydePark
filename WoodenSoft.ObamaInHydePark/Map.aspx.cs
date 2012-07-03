using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;
using WoodenSoft.ObamaInHydePark.Controls;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class Map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                BindMap();
            }
            catch(Exception ex)
            {
                pnlMap.Controls.Add(new LiteralControl("Map Directions Not Set Up Correctly"));
            }
        }
        private void BindMap()
        {
            var mapPoints = new MapPointRepository().GetAllPoints().OrderBy( x=> x.Ordinal);
            if (!mapPoints.Any())
                return;
            var litDirections = new Literal();
            var sb = new StringBuilder();
            var steps = GeoDirectionsHelper.GetDirectionSteps(mapPoints);
            sb.Append("<ol class='directions'>");
            foreach (var step in steps)
            {
                sb.Append("<li>" + step + "</li>");
            }
            sb.Append("</ol>");
            litDirections.Text = sb.ToString();
            //var hf = new HiddenField();
            //hf.ID = "hfMapJson";
            //hf.ClientIDMode = ClientIDMode.Predictable;
            var map = new GoogleMap
                          {
                              ApiKey = ConfigurationManager.AppSettings["GoogleApiKey"],
                              Width = 400,
                              Height = 400,
                              MarkerColor = "red",
                              GeoPoints = mapPoints
                          };
            pnlMap.Controls.Add(map);
            //var js = new JavaScriptSerializer();

            //var json = js.Serialize(mapPoints);
            //hf.Value = json;
            //pnlMap.Controls.Add(hf);
            if (!string.IsNullOrEmpty(Request["OrderNumber"]))
            {
                var orderRepo = new OrderRepository();
                if (orderRepo.ValidateOrder(Request["OrderNumber"], ProcessedValue.Map))
                {
                    pnlMap.Controls.Add(litDirections);
                    var order1 =
                        orderRepo.GetAllOrders().First(
                            x =>
                            x.OrderNumber == Request["OrderNumber"] && x.HasBeenProcessed == (int)ProcessedValue.Map);
                    orderRepo.FulFillOrder(order1);
                }
            }
            
        }
    }
}