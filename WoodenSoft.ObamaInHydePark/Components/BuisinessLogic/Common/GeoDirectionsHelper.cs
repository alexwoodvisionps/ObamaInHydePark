using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common
{
    public class GeoDirectionsHelper
    {
        public static IEnumerable<string> GetDirectionSteps(IEnumerable<MapPoint> mapPoints)
        {
            var steps = new List<string>();
            MapPoint oldPoint = null;
            foreach (var mapPoint in mapPoints)
            {
                
                if(oldPoint == null)
                {
                    oldPoint = mapPoint;
                    continue;                    
                }
                Thread.Sleep(500);
                var request =
                    WebRequest.Create("http://maps.googleapis.com/maps/api/directions/xml?origin=" + oldPoint.Address +
                                      "&destination=" + mapPoint.Address + "&mode=walking&sensor=true");
                var res = request.GetResponse();
                var reader = new StreamReader(res.GetResponseStream());
                var xml = reader.ReadToEnd();
                var doc = new XmlDocument();
                doc.LoadXml(xml);
                var legNodes = doc.SelectNodes("//leg");
                if (legNodes == null)
                {
                    //steps.Add(xml);
                    continue;
                    
                }
                var sb = new StringBuilder();
                foreach (XmlElement legNode in legNodes)
                {
                    var stepNodes = legNode.SelectNodes("//step");
                    if (stepNodes == null)
                        return null;
                    foreach (XmlElement stepsNode in stepNodes)
                    {
                        sb.Append(stepsNode.SelectSingleNode("html_instructions").InnerText);
                    }
                }
                //sb.AppendLine(xml);
                steps.Add(sb.ToString());
                oldPoint = mapPoint;
                
            }
            return steps;
        }
    }
}