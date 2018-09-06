using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GRADEXPO.ViewModels
{
    public class VendorViewModel : BaseViewModel
    {
        [Display(Name = "Код поставщика")]
        public string vendAccount { get; set; }
        public Int32 vendorId { get; set; }
        [Display(Name = "Описание")]
        public string description { get; set; }
        [Display(Name = "Наименование поставщика")]
        public string vendorName { get; set; }
    }
}