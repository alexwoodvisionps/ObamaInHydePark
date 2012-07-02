using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Xml;

namespace WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common
{
    public class GeoLocation
    {
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
    }

    public class GeoCoder
    {
        public static GeoLocation GeoCode(string address)
        {
            var request =
                WebRequest.Create("http://maps.google.com//maps/api/geocode/xml?address=" +
                                  HttpUtility.UrlEncode(address) + "&sensor=true") as HttpWebRequest;
            if(request == null)
                throw new Exception("Error Translating Address To Geo Coordinates From Google Api");
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var rawXml = reader.ReadToEnd();
            var doc = new XmlDocument();
            doc.LoadXml(rawXml);
            var latlongNodes = doc.SelectNodes("//geometry/location");
            if(latlongNodes == null)
                throw new Exception("Error Translating Address To Geo Coordinates From Google Api");
            var lat = latlongNodes[0].FirstChild.InnerText;
            var longC = latlongNodes[0].FirstChild.NextSibling.InnerText;
            return  new GeoLocation{Lat = decimal.Parse(lat), Long = decimal.Parse(longC)};
        }
    }
}