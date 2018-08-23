using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class ProductFromJson
    {
        public class Product
        {
            public Int32 productId { get; set; }
            public string description { get; set; }
            public Int32 projectId { get; set; }
            public string productName { get; set; }
        }

        public class Values
        {
            public List<Product> value { get; set; }
        }
    }
}