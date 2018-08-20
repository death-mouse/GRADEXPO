using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class ProductSampleFromJson
    {
        public class ProductSample
        {
            public Int32 sampleId { get; set; }
            public Int32 productId { get; set; }
        }

        public class Values
        {
            public List<ProductSampleFromJson> value { get; set; }
        }
    }
}