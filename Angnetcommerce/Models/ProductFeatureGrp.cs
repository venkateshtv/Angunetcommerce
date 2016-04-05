using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angnetcommerce.Models
{
    public class ProductFeatureGrp
    {
        public vehicle_for_sale Product { get; set; }
        public features_on_vehicles_for_sale Feature { get; set; }
        public images_on_vehicles_for_sale Image { get; set; }
    }
}