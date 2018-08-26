using GRADEXPO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GRADEXPO.Models;
using System.Threading.Tasks;

namespace GRADEXPO.Content
{
    public class PlanVisitController : Controller
    {
        private readonly IVisitService visitService;

        public PlanVisitController(IVisitService _visitService)
        {
            visitService = _visitService;
        }
        // GET: PlanVisit
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> VisitByExpo(int expoId)
        {
            IEnumerable<VisitFromJson.Visit> visits = await visitService.getVisitsByExpo(expoId);
            return View(visits);
        }
    }
}