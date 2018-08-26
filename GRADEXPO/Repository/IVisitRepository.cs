using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public interface IVisitRepository
    {
        Task<VisitFromJson.Visit> getVisit(int _visitId);
        Task<VisitFromJson.Visit> getVisit(int _visitId, int _expoId);

        Task<IEnumerable<VisitFromJson.Visit>> getVisitsByExpo(int _expoId);

        Task<VisitFromJson.Visit> addVisit(VisitFromJson.Visit _visit);
        Task<VisitFromJson.Visit> updateVisit(VisitFromJson.Visit _visit);
        Task deleteVisit(int _visitId);
    }
}