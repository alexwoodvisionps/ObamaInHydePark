using System;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Models
{
    [Serializable]
    public class Settings
    {
        public string ContactPhone { get; set; }
        public string LogoUrl { get; set; }
        public string AboutUs { get; set; }
        public string ContactAddress { get; set; }
        public string HomePageMessage { get; set; }
        public string ContactEmail { get; set; }
        public string Terms { get; set; }
        public string ITunesUrl { get; set; }
    }
}