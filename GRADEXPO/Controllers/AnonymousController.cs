using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GRADEXPO.Controllers
{
    public class AnonymousController : Controller
    {
        // GET: Anonymous
        public ActionResult Index()
        {
            ViewBag.UserName = HttpContext.User.Identity.Name.ToLower();
            return View();
        }
    }
}