using GRADEXPO.Services;
using GRADEXPO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GRADEXPO.Models;
using GRADEXPO.ViewModels;
using System.IO;

namespace GRADEXPO.Controllers
{
    public class ExpoFilesController : Controller
    {
        readonly IExpoFilesService expoFilesService;
        public ExpoFilesController(IExpoFilesService _expoFilesService)
        {
            expoFilesService = _expoFilesService;
        }
        // GET: ExpoFiles
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetFileFromExpoFile(List<ExpoFilesFromJson.ExpoFiles> expoFilesFromJson)
        {
            List<FileFromJson.File> fileFromJsons = new List<FileFromJson.File>();
            FileService fileService = new FileService(new FileRepository());
            foreach(ExpoFilesFromJson.ExpoFiles expoFile in expoFilesFromJson)
            {
                FileFromJson.File file = await fileService.GetFileJsonAsync(expoFile.fileId);
                fileFromJsons.Add(file);
            }

            return View(fileFromJsons);
        }

        public async Task<ActionResult> DownloadFile(int fileId)
        {
            FileService fileService = new FileService(new FileRepository());
            FileFromJson.File file = await fileService.GetFileJsonAsync(fileId);
            return File(Convert.FromBase64String(file.content), System.Net.Mime.MediaTypeNames.Application.Octet, file.filename);
        }

        public ActionResult AddFile2Expo(int expoId)
        {
            var exposFilesViewModel = new ExposFilesViewModel
            {
                Title = "Создание новой выставки",
                AddButtonTitle = "Создать",
                RedirectUrl = Url.Action("DetailsOfExpo", "Expos", new { _idExpo = expoId }),
            };


            return View(exposFilesViewModel);
        }

        public async Task<ActionResult> addFile(ExposFilesViewModel exposFilesViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(exposFilesViewModel);
            }
            var expoFile = new ExpoFilesFromJson.ExpoFiles()
            {
                expoId = exposFilesViewModel.expoId
            };
            FileRepository fileRepository = new FileRepository();
            byte[] bytes;
            if (exposFilesViewModel.file != null)
            {
                using (Stream inputStream = exposFilesViewModel.file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    bytes = memoryStream.ToArray();
                }

                String fileBase64 = Convert.ToBase64String(bytes);
                FileFromJson.File file = new FileFromJson.File()
                {
                    authorId = 2,
                    content = fileBase64,
                    filename = exposFilesViewModel.file.FileName,
                    fileType = "file",
                    dateTime = DateTimeOffset.Now
                };
                file = await fileRepository.AddFileFromJsonAsync(file);
                expoFile.fileId = file.fileId;
            }
            await expoFilesService.AddExpoFilesFromJsonAsync(expoFile, "expoFile");

            return RedirectToLocal(exposFilesViewModel.RedirectUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Expos");
        }
    }
}