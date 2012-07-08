using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Controls
{
    public class GoogleMap : Control
    {
        public string ApiKey { get; set; }
        public IEnumerable<MapPoint> GeoPoints { get; set; }
        public string MarkerColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public override void RenderControl(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var url = "http://maps.googleapis.com/maps/api/staticmap?center=Hyde Park, Chicago, IL&zoom=10&size=" + Width +
                      "x" + Height + "&markers=color:" + MarkerColor + "|label:Stop|";
            foreach (var mapPoint in GeoPoints)
            {
                sb.Append(mapPoint.Lat + "," + mapPoint.Long + "|");
            }
            url += sb.ToString().Substring(0, sb.ToString().Length - 1) + "&sensor=true";//"&key=" + ApiKey;
            sb.Clear();
            sb.AppendLine("<img src='" + url + "' width='" + Width + "' height='" + Height + "' alt='Obama In Hyde Park Tour Map' class='googlemap' />");
            writer.WriteLine(sb.ToString());
//&markers=color:blue%7Clabel:S%7C62.107733,-145.541936"
        }
    }
}