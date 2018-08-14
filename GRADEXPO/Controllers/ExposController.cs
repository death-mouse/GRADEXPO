using System.Threading.Tasks;
using System.Web.Mvc;
using GRADEXPO.Services;
using GRADEXPO.ViewModels;
using GRADEXPO.Models;
using System;
using System.Configuration;
using System.Collections.Generic;

namespace GRADEXPO.Controllers
{
    public class ExposController : Controller
    {
        private readonly IExposService expoService;

        public ExposController(IExposService _expoService)
        {
            expoService = _expoService;
        }


        // GET: Expo
        public async Task<ActionResult> Index()
        {
            IEnumerable<Expos> expos = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    expos = await expoService.GetExposAsync();
                    break;
                case "Json":
                    expos = await expoService.GetExposFromJsonAsync();
                    break;

            }


            return View(expos);
        }

        public ActionResult AddExpos()
        {
            var exposViewModel = new ExposViewModel
            {
                Title = "Создание новой выставки",
                AddButtonTitle = "Создать",
                RedirectUrl = Url.Action("Index", "Expos")
            };

            return View(exposViewModel);
        }

        [HandleError]
        public async Task<ActionResult> DetailsOfExpo(int Id)
        {
            //try
            {
                Expos expo = null;
                switch (Properties.Settings.Default.GetDataFrom)
                {
                    case "db":
                        expo = await expoService.GetExpoAsync(Id);
                        break;
                    case "Json":
                        expo = await expoService.GetExpoFromJsonAsync(Id);
                        break;
                }
                return View(new ExposViewModel { Id = expo.expoId, DateStart = expo.startDate, DateEnd = expo.endDate, ExpoName = expo.expoName, Description = expo.description });
            }
            /*catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Expos", "DetailsOfExpo"));
            }*/
        }

        [HttpPost]
        public async Task<ActionResult> SaveExpo(ExposViewModel _expoViewModel, string _redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(_expoViewModel);
            }

            var expo = await expoService.GetExpoAsync(_expoViewModel.Id);
            if (expo != null)
            {
                expo.expoName = _expoViewModel.ExpoName;
                expo.startDate = _expoViewModel.DateStart;
                expo.endDate = _expoViewModel.DateEnd;
                await expoService.UpdateExpoAsync(expo);
            }

            return RedirectToLocal(_expoViewModel.RedirectUrl);
        }
        public async Task<ActionResult> EditExpo(int Id)
        {
            var expo = await expoService.GetExpoAsync(Id);
            var exposViewModel = new ExposViewModel
            {
                Title = "Изменение выставки",
                AddButtonTitle = "Сохранить",
                RedirectUrl = Url.Action("Index", "Expos"),
                ExpoName = expo.expoName,
                DateStart = expo.startDate,
                DateEnd = expo.endDate
            };

            return View(exposViewModel);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Expos");
        }
        [HttpPost]
        public async Task<ActionResult> AddNewExpo(ExposViewModel _exposViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(_exposViewModel);
            }

            var expo = new Expos
            {
                expoName = _exposViewModel.ExpoName,
                startDate = _exposViewModel.DateStart,
                endDate = _exposViewModel.DateEnd
            };

            await expoService.AddExpoAsync(expo);

            return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> DeleteExpo(int id)
        {
            await expoService.DeleteExpoAsync(id);

            return RedirectToAction("Index");
        }
    }
}