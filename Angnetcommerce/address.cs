//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Angnetcommerce
{
    using System;
    using System.Collections.Generic;
    
    public partial class address
    {
        public int addressid { get; set; }
        public int customerid { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Nullable<int> zip_code { get; set; }
        public string description { get; set; }
    }
}