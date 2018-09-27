using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Services
{
    public interface IVisitService
    {
        Task<VisitFromJson.Visit> getVisit(int _visitId);
        Task<VisitFromJson.Visit> getVisit(int _visitId, int _expoId);

        Task<IEnumerable<VisitFromJson.Visit>> getVisitsByExpo(int _expoId);

        Task<VisitFromJson.Visit> addVisit(VisitFromJson.Visit _visit);
        Task<VisitFromJson.Visit> updateVisit(VisitFromJson.Visit _visit);
        Task deleteVisit(int _visitId);

        Task<PlanVisitFromjson.PlanVisit> addPlanVisit(PlanVisitFromjson.PlanVisit _visit);
        Task addPlanVisitUser(PlanUserVisits.PlanUserVisit planUserVisit);
        Task<IEnumerable<PlanUserVisits.PlanUserVisit>> getUserByPlanId(int planVisitId);
    }
}