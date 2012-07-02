using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Models
{
    public class MapPoint
    {
        public int Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public int Ordinal { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}