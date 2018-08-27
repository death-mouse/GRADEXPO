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

        public ActionResult VisitByExpo(List<GRADEXPO.Models.VisitFromJson.Visit> visits, List<Models.PlanVisitFromjson.PlanVisit> planVisit)
        {
            List<Models.PlanVisitModel> planVisitModels = new List<PlanVisitModel>();
            foreach (Models.VisitFromJson.Visit visitFromJson in visits)
            {
                planVisitModels.Add(new PlanVisitModel()
                {
                    title = visitFromJson.comment,
                    start = visitFromJson.visitDateTime.DateTime,
                    type = 0

                });
            }
            foreach (Models.PlanVisitFromjson.PlanVisit planVisitOne in planVisit)
            {
                planVisitModels.Add(new PlanVisitModel()
                {
                    title = planVisitOne.Comments,
                    start = planVisitOne.planvisitDateTime,
                    type = 1

                });
            }

            return View(planVisitModels);
        }
    }
}