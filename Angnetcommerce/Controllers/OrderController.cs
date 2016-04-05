using Angnetcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Angnetcommerce.Controllers
{
    public class OrderController : ApiController
    {
        // MyOrders
        //OrderItem
        [HttpPost]
        public bool OrderItem(Product product,string customerId)
        {
            var result = false;
            try
            {
                
            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
