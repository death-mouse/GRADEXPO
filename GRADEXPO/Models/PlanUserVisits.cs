using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class PlanUserVisits
    {
        public class PlanUserVisit
        {
            public int userId { get; set; }
            public int planVisitId { get; set; }
        }
        public class Value
        {
            public List<PlanUserVisit> value { get; set; }
        }
    }
}