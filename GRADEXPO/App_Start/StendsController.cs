using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GRADEXPO.App_Start
{
    public class StendsController : Controller
    {
        // GET: Stends
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> DetailStandOnExpo( int _idExpo)
        {
            Models.Stands stands = null;
            return View(stands);
        }
    }
}