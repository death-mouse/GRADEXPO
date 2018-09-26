using GRADEXPO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GRADEXPO.Models;
using System.Threading.Tasks;
using GRADEXPO.ViewModels;
using GRADEXPO.Repository;
using System.Collections;

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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult VisitByExpo(List<GRADEXPO.Models.VisitFromJson.Visit> visits, List<Models.PlanVisitFromjson.PlanVisit> planVisit)
        {
            List<PlanVisitViewModel> planVisitModels = new List<PlanVisitViewModel>();
            foreach (Models.VisitFromJson.Visit visitFromJson in visits)
            {
                planVisitModels.Add(new PlanVisitViewModel()
                {
                    Title = visitFromJson.comment,
                    start = visitFromJson.visitDateTime.DateTime,
                    type = 0

                });
            }
            foreach (Models.PlanVisitFromjson.PlanVisit planVisitOne in planVisit)
            {
                planVisitModels.Add(new PlanVisitViewModel()
                {
                    Title = planVisitOne.Comments,
                    start = planVisitOne.planvisitDateTime,
                    type = 1

                });
            }

            return View(planVisitModels);
        }
        [Authorize]
        public async Task<ActionResult> AddPlanVisit(int expoId, int standId, int vendorId)
        {
            PlanVisitViewModel planVisitModel = new PlanVisitViewModel()
            {

                Title = "Запланировать визит",
                AddButtonTitle = "Запланировать",
                expoId = expoId,
                standId = standId,
                vendorId = vendorId,
                RedirectUrl = Url.Action("DetailsOfExpo", "Expos", new { _idExpo = expoId }),
                planvisitDateTime = DateTime.UtcNow

            };
            IEnumerable <Users.User> users = await new UsersService(new UsersRepository()).GetUsersAsync();
            
            MultiSelectList userList = new MultiSelectList(users, "userId", "UserName");
            ViewBag.UserList = userList;
            return View(planVisitModel);
        }
        [Authorize]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Expos");
        }
        [Authorize]
        public async Task<ActionResult> AddNewPlanVisit(PlanVisitViewModel planVisitViewModel, string redirectUrl, int[] userList)
        {
           if(!ModelState.IsValid)
            {
                return View(planVisitViewModel);
            }
            
            PlanVisitFromjson.PlanVisit planVisit = new PlanVisitFromjson.PlanVisit()
            {
                Comments = planVisitViewModel.Comments,
                expoId = planVisitViewModel.expoId,
                planvisitDateTime = planVisitViewModel.planvisitDateTime,
                standId = planVisitViewModel.standId,
                vendorId = planVisitViewModel.vendorId
            };

            planVisit = await visitService.addPlanVisit(planVisit);
            if (userList != null)
            {
                foreach (int userId in userList)
                {
                    PlanUserVisits.PlanUserVisit planUserVisit = new PlanUserVisits.PlanUserVisit()
                    {
                        planVisitId = planVisit.planVisitId,
                        userId = userId
                    };
                    await new VisitRepository().addPlanVisitUser(planUserVisit);
                }
            }
            return RedirectToLocal(planVisitViewModel.RedirectUrl);
        }
    }
}