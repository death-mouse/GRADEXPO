using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class ProductFilesFromJson
    {
        public class ProductFiles
        {
            public Int32 productId { get; set; }
            public Int32 fileId { get; set; }
        }

        public class Values
        {
            public List<ProductFiles> value { get; set; }
        }
    }
}