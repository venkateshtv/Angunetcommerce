using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angnetcommerce.Models
{
    public class Product
    {
        public int Stock_No { get; set; }
        public string Model { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public int? Year { get; set; }
        public string Month { get; set; }
        public string chassis_no_1 { get; set; }
        public string chassis_no_2 { get; set; }
        public string Maker { get; set; }
        public string ProductType { get; set; }
        public string Grade { get; set; }
        public string ETD { get; set; }
        public string Color { get; set; }
        public int? KM_ran { get; set; }
        public string Fuel { get; set; }
        public string Gear_m_at { get; set; }
        public int? CC { get; set; }
        public string[] Images { get; set; }
        public int? NoOfDoors { get; set; }
        public string LastModifiedDate { get; set; }
        private Equipment _Equipments = new Equipment();
        public Equipment Equipments
        {
            get
            {
                return _Equipments;
            }
            set
            {
                _Equipments = value;
            }
        }
    }

}