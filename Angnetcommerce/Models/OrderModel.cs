using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angnetcommerce.Models
{
    public class OrderModel
    {
        public int stockno { get; set; }
        public decimal price { get; set; }
        public int customerid { get; set; }
    }
}