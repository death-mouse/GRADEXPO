using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GRADEXPO.Models;
using Microsoft.Owin.Security;
using System.Security.Cryptography;
using System.DirectoryServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace GRADEXPO.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
       [HttpGet]
       [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Index(GRADEXPO.ViewModels.LoginViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            int idx = await findUser(model.Username);
            if (idx == 0)
            {
                ModelState.AddModelError("", "Пользователь не найден в системе GREXPO");
                return View(model);
            }
            if (idx == -1)
            {
                ModelState.AddModelError("", "Найдено больше одной записи в пользователях для данного логина, обратитеть к администрации проекта");
                return View(model);
            }
            Session["UserId"] = idx;
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            var authService = new AdAuthenticationService(authenticationManager);

            var authenticationResult = authService.SignIn(model.Username, model.Password, Server.MapPath("~/UserPhoto"));
            
            if (authenticationResult.IsSuccess)
            {
                
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", authenticationResult.ErrorMessage);
            return View(model);
        }

        private async Task<int> findUser(string _userName)
        {
            Services.UsersService usersService = new Services.UsersService(new Repository.UsersRepository());
            var users = await usersService.GetUsersAsync() as List<Users.User>;
            List<Users.User> user = users.Where(u => u.login == _userName).ToList();
            if (user.Count == 1)
                return user[0].userId;
            else
            {
                if (user.Count > 1)
                    return -1;
            }
            return 0;
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Logoff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(MyAuthentication.ApplicationCookie);

            return RedirectToAction("Index");
        }
    }

}