using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class VendorFromJson
    {
        public class Vendor
        {
            [Display (Name = "Код поставщика")]
            public string vendAccount { get; set; }
            public Int32 vendorId { get; set; }
            [Display(Name = "Описание")]
            public string description { get; set; }
            [Display(Name = "Наименование поставщика")]
            public string vendorName { get; set; }
        }

        public class Values
        {
            public List<Vendor> value { get; set; }
        }
    }
}