using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class VendorContactsFromJson
    {
        public class VendorContacts
        {
            public string im { get; set; }
            public Int32 contactId { get; set; }
            public string phone { get; set; }
            public string contactPosition { get; set; }
            public string contactPerson { get; set; }
            public string description { get; set; }
            public Int32 vendorId { get; set; }
            public string email { get; set; }
        }

        public class Values
        {
            public List<VendorContacts> value { get; set; }
        }
    }

    

}