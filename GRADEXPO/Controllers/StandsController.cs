using GRADEXPO.Models;
using GRADEXPO.Services;
using GRADEXPO.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
        [Authorize]
        public ActionResult AddStand(int expoId)
        {
            var standViewModel = new StandsViewModel
            {
                Title = "Импорт Стендов",
                AddButtonTitle = "Создать",
                RedirectUrl = Url.Action("DetailsOfExpo", "Expos", new { _idExpo = expoId }),
                expoId = expoId
            };


            return View(standViewModel);
        }
        public async Task<ActionResult> SaveStand(StandsViewModel standViewModel)
        {
            Stands stands = new Stands()
            {
                expoId = standViewModel.expoId,
                description = standViewModel.description,
                hall = standViewModel.hall,
                vendorId = standViewModel.vendorId
            };

            Stands newStand = await standsService.AddStandAsync(stands);

            return RedirectToLocal(standViewModel.RedirectUrl);
        }
        [Authorize]
        public ActionResult impStand(int expoId, string buttonTile)
        {
            var standViewModel = new StandsViewModel
            {
                Title = "Импорт Стендов",
                AddButtonTitle = "Создать",
                RedirectUrl = Url.Action("DetailsOfExpo", "Expos", new { _idExpo = expoId }),
                expoId = expoId
            };


            return View(standViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> ImportStands(StandsViewModel standViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(standViewModel);
            }

            if (standViewModel.importFile != null)
            {
                using (var reader = new StreamReader(standViewModel.importFile.InputStream, System.Text.Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        Stands stands = new Stands();
                        stands.vendorId = Convert.ToInt16(values[0]);
                        stands.description = values[1];
                        stands.hall = values[2];
                        stands.expoId = standViewModel.expoId;
                        Stands newStand = await standsService.AddStandAsync(stands);
                        if (newStand.standId != 0)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }

            return RedirectToLocal(standViewModel.RedirectUrl);
        }

        public async Task<ActionResult> SaveStands(StandsViewModel standViewModel)
        {
            Stands stands = new Stands()
            {
                expoId = standViewModel.expoId,
                hall = standViewModel.hall,
                vendorId = standViewModel.vendorId
            };

            Stands newStand = await standsService.AddStandAsync(stands);

            return RedirectToLocal(standViewModel.RedirectUrl);
        }

        [Authorize]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Stands");
        }
    }
}