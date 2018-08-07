using System.Threading.Tasks;
using System.Web.Mvc;
using GRADEXPO.Services;
using GRADEXPO.ViewModels;
using GRADEXPO.Models;
using System;

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
            var expos = await expoService.GetExposAsync();

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

        public async Task<ActionResult> DetailsOfExpo(int Id)
        {
            var expo = await expoService.GetExpoAsync(Id);

            return View(new ExposViewModel { Id = expo.Id, DateStart = expo.StartDate, DateEnd = expo.EndDate, ExpoName = expo.ExpoName });
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
                expo.ExpoName = _expoViewModel.ExpoName;
                expo.StartDate = _expoViewModel.DateStart;
                expo.EndDate = _expoViewModel.DateEnd;
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
                ExpoName = expo.ExpoName,
                DateStart = expo.StartDate,
                DateEnd = expo.EndDate
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
                ExpoName = _exposViewModel.ExpoName,
                StartDate = _exposViewModel.DateStart,
                EndDate = _exposViewModel.DateEnd
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