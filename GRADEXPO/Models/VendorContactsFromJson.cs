using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class VendorContactsFromJson
    {
        public class VendorContacts
        {
            [Display(Name = "Мессанджер")]
            public string im { get; set; }
            public Int32 contactId { get; set; }
            [Display(Name = "Телефон")]
            public string phone { get; set; }
            [Display(Name = "Должность")]
            public string contactPosition { get; set; }
            public string contactPerson { get; set; }
            [Display(Name = "Описание")]
            public string description { get; set; }
            public Int32 vendorId { get; set; }
            [Display(Name = "EMail")]
            public string email { get; set; }
        }

        public class Values
        {
            public List<VendorContacts> value { get; set; }
        }
    }

    

}