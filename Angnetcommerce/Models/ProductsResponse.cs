using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angnetcommerce.Models
{
    public class ProductsResponse
    {
        public Product[] products { get; set; }
        public int count { get; set; }
    }
}