using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class UserVisitsFromJson
    {
        public class UserVisits
        {
            public Int32 visitId { get; set; }
            public Int32 userId { get; set; }
        }

        public class Values
        {
            List<UserVisits> value { get; set; }
        }
    }
}