using System.Threading.Tasks;
using System.Web.Mvc;
using GRADEXPO.Services;
using GRADEXPO.ViewModels;
using GRADEXPO.Models;
using System;
using System.Configuration;
using System.Collections.Generic;
using Simple.OData.Client;
using System.Net;
using Microsoft.Data.OData;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Newtonsoft.Json;
using System.Web;
using GRADEXPO.Repository;
using System.IO;

namespace GRADEXPO.Controllers
{
    public class ExpoTest
    {
        public string ExpoName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public string Description { get; set; }
    }
    public class ExposController : Controller
    {
        private readonly IExposService expoService;

        public ExposController(IExposService _expoService)
        {
            expoService = _expoService;
        }


        // GET: Expo
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult> DetailsOfExpo(int _idExpo)
        {
            {
                Expos expo = null;
                switch (Properties.Settings.Default.GetDataFrom)
                {
                    case "db":
                        expo = await expoService.GetExpoAsync(_idExpo);
                        break;
                    case "Json":
                        expo = await expoService.GetExpoFromJsonAsync(_idExpo);
                        break;
                }
                return View(new ExposViewModel { Id = expo.expoId, DateStart = expo.startDate, DateEnd = expo.endDate, ExpoName = expo.expoName, Description = expo.description, Stands = expo.Stand, Visit = expo.Visit, PlanVisits = expo.PlanVisit });
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SaveExpo(ExposViewModel _expoViewModel, string _redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(_expoViewModel);
            }
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    var expo = await expoService.GetExpoAsync(_expoViewModel.Id);
                    if (expo != null)
                    {
                        expo.expoName = _expoViewModel.ExpoName;
                        expo.startDate = _expoViewModel.DateStart;
                        expo.endDate = _expoViewModel.DateEnd;
                        await expoService.UpdateExpoAsync(expo);
                    }
                    break;
                case "Json":
                    var expo2 = await expoService.GetExpoFromJsonAsync(_expoViewModel.Id);
                    if (expo2 != null)
                    {
                        expo2.expoName = _expoViewModel.ExpoName;
                        expo2.startDate = _expoViewModel.DateStart;
                        expo2.endDate = _expoViewModel.DateEnd;
                        expo2.description = _expoViewModel.Description;
                    }
                    await expoService.UpdateExpoFromJsonAsync(expo2);
                    break;
            }
            

            return RedirectToLocal(_expoViewModel.RedirectUrl);
        }
        [Authorize]
        public async Task<ActionResult> EditExpo(int Id)
        {
            var exposViewModel = new ExposViewModel();
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    var expo = await expoService.GetExpoAsync(Id);
                    exposViewModel = new ExposViewModel
                    {
                        Title = "Изменение выставки",
                        AddButtonTitle = "Сохранить",
                        RedirectUrl = Url.Action("Index", "Expos"),
                        ExpoName = expo.expoName,
                        DateStart = expo.startDate,
                        DateEnd = expo.endDate,
                        Description = expo.description
                    };
                    break;
                case "Json":
                    var expo2 = await expoService.GetExpoFromJsonAsync(Id);
                    exposViewModel = new ExposViewModel
                    {
                        Title = "Изменение выставки",
                        AddButtonTitle = "Сохранить",
                        RedirectUrl = Url.Action("DetailsOfExpo", "Expos", new { _idExpo = Id }),
                        ExpoName = expo2.expoName,
                        DateStart = expo2.startDate,
                        DateEnd = expo2.endDate,
                        Description = expo2.description
                    };
                    break;

            }

            return View(exposViewModel);
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
        [HttpPost]
        public async Task<ActionResult> AddNewExpo(ExposViewModel _exposViewModel, string redirectUrl, HttpPostedFileBase uploadImage)
        {
            if (!ModelState.IsValid)
            {
                return View(_exposViewModel);
            }
            var expo = new Expos
            {
                expoName = _exposViewModel.ExpoName,
                startDate = _exposViewModel.DateStart,
                endDate = _exposViewModel.DateEnd,
                description = _exposViewModel.Description,
                
            };
            FileRepository fileRepository = new FileRepository();
            byte[] bytes;
            if (_exposViewModel.logoFile != null)
            {
                using (Stream inputStream = _exposViewModel.logoFile.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    bytes = memoryStream.ToArray();
                }
                //Byte[] bytes = _exposViewModel.logoFile.//System.IO.File.ReadAllBytes(expos.logoFile);
                String fileBase64 = Convert.ToBase64String(bytes);
                FileFromJson.File file = new FileFromJson.File()
                {
                    authorId = 2,
                    content = fileBase64,
                    filename = _exposViewModel.logoFile.FileName,
                    fileType = "logo",
                    dateTime = DateTimeOffset.Now
                };
                file = await fileRepository.AddFileFromJsonAsync(file);
                expo.logoFileId = file.fileId;
            }
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":

                    await expoService.AddExpoAsync(expo);
                    break;
                case "Json":
                    await expoService.AddExpoFromJsonAsync(expo);
                    break;

            }
            return RedirectToLocal(redirectUrl);
        }

        [Authorize]
        public async Task<ActionResult> DeleteExpo(int id)
        {
            await expoService.DeleteExpoAsync(id);

            return RedirectToAction("Index");
        }
    }
}