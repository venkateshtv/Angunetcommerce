using Angnetcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Angnetcommerce.Controllers
{
    public class ProductController : ApiController
    {
        Product[] products = new Product[]
       {
            new Product { Name = "Honda City", Price = 250000 },
            new Product {Name = "Renault Scala", Price = 250000 },
            new Product {Name = "Mercedes Benz",Price = 250000}
       };

        [HttpGet]
        public Product[] GetProducts()
        {
            return products;
        }

    }
}
