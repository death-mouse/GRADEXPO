using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class StandStatusHistoryFromJson
    {
        public class StandStatusHistory
        {
            public DateTimeOffset datetime { get; set; }
            public Int32 expoId { get; set; }
            public Int32 statusId { get; set; }
            public Int32 standId { get; set; }
            public Int32 userId { get; set; }
        }

        public class Values
        {
            public List<StandStatusHistory> value { get; set; }
        }
    }
}