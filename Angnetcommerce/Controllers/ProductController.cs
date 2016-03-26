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
            new Product { Stock_No = 1, Model = "Honda City",Currency ="USD", Price = 250000, Year=2014, Month="Jan", CC= 1500, Color="White", Maker="Honda", Fuel="Petrol", KM_ran=27000, Gear_m_at="A/T", Grade="SE Saloon", Type="Sedan" },
            new Product {Stock_No =2 , Model = "Renault Scala", Currency ="USD",Price = 250000 , Year=2013, Month="Dec"},
            new Product {Stock_No = 3, Model = "Mercedes Benz", Currency ="USD",Price = 250000 , Year=2015, Month="Feb"}
       };

        [HttpGet]
        public Product[] GetProducts()
        {
            return products;
        }
        // Product Filters

        //Get products Apply Filters


    }
}
