using Angnetcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Angnetcommerce.Controllers
{
    public class OrderController : ApiController
    {
        // MyOrders
        //OrderItem
        [HttpPost]
        public bool OrderItem([FromBody]OrderModel data)
        {
            var result = false;
            if (data == null) return false;
            try
            {
                AaauctionEntities db = new AaauctionEntities();
                var orderItem = new vehicle_order();
                orderItem.stock_no = data.stockno;
                orderItem.customerid = data.customerid;
                orderItem.price = data.price;
                orderItem.order_date = DateTime.Now;
                orderItem.ispaid = false;
                db.vehicle_order.Add(orderItem);
                db.SaveChanges();
                var product = db.vehicle_for_sale.Where(x => x.stock_no == data.stockno).Select(y => y).FirstOrDefault();
                product.is_sold = true;
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            return result;
        }
    }
}
