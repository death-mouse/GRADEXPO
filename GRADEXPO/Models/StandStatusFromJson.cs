using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class StandStatusFromJson
    {
        public class StandStatus
        {
            public Int32 statusId { get; set; }
            public string statusName { get; set; }
        }

        public class Values
        {
            public List<StandStatus> value { get; set; }
        }
    }
}