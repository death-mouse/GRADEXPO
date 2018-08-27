using GRADEXPO.Models;
using GRADEXPO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GRADEXPO.Controllers
{
    public class StandsController : Controller
    {
        private readonly IStandsService standsService;

        public StandsController(IStandsService _standsService)
        {
            standsService = _standsService;
        }
        // GET: Stands
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InfoAboutStandsInExpo(List<GRADEXPO.Models.Stands> stands)
        {
            return View(stands);
        }
    }
}