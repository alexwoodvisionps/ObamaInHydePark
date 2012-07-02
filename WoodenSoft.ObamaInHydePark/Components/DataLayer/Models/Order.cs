using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Models
{
    public class Order
    {
        public int HasBeenProcessed { get; set; }
        public string OrderNumber { get; set; }
        public int Id { get; set; }
        public string Email { get; set; } 
    }
}