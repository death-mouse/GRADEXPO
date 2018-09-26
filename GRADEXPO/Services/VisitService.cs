using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using GRADEXPO.Repository;

namespace GRADEXPO.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository visitRepository;

        public VisitService(IVisitRepository _visitRepository)
        {
            visitRepository = _visitRepository;
        }

        public async Task<PlanVisitFromjson.PlanVisit> addPlanVisit(PlanVisitFromjson.PlanVisit _visit)
        {
            return await visitRepository.addPlanVisit(_visit);
        }

        public async Task addPlanVisitUser(PlanUserVisits.PlanUserVisit planUserVisit)
        {
            await visitRepository.addPlanVisitUser(planUserVisit);
        }

        public async Task<VisitFromJson.Visit> addVisit(VisitFromJson.Visit _visit)
        {
            return await visitRepository.addVisit(_visit);
        }

        public async Task deleteVisit(int _visitId)
        {
            await visitRepository.deleteVisit(_visitId);
        }

        public async Task<VisitFromJson.Visit> getVisit(int _visitId)
        {
            return await visitRepository.getVisit(_visitId);
        }

        public async Task<VisitFromJson.Visit> getVisit(int _visitId, int _expoId)
        {
            return await visitRepository.getVisit(_visitId, _expoId);
        }

        public async Task<IEnumerable<VisitFromJson.Visit>> getVisitsByExpo(int _expoId)
        {
            return await visitRepository.getVisitsByExpo(_expoId);
        }

        public async Task<VisitFromJson.Visit> updateVisit(VisitFromJson.Visit _visit)
        {
            return await visitRepository.updateVisit(_visit);
        }
    }
}