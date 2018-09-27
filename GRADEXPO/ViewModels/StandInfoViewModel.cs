using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.ViewModels
{
    public class StandInfoViewModel : BaseViewModel
    {
        public List<Stands> Stands { get; set; }
        public List<PlanVisitFromjson.PlanVisit> planVisits {get; set;}
        public IEnumerable<Users.User> Users { get; set; }
        public List<PlanUserVisits.PlanUserVisit> planUserVisits { get; set; }
    }
}