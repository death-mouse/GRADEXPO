using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class PlanVisitFromjson
    {
        public class PlanVisit
        {
            public int expoId { get; set; }
            public string Comments { get; set; }
            public int standId { get; set; }
            public int planVisitId { get; set; }
            public int vendorId { get; set; }
            public DateTime planvisitDateTime { get; set; }
        }
    }
}