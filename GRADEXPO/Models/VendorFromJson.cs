using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class VendorFromJson
    {
        public class Vendor
        {
            public string vendAccount { get; set; }
            public Int32 vendorId { get; set; }
            public string description { get; set; }
            public string vendorName { get; set; }
        }

        public class Values
        {
            public List<Vendor> value { get; set; }
        }
    }
}