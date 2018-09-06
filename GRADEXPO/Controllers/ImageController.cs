using GRADEXPO.Models;
using GRADEXPO.Repository;
using GRADEXPO.Services;
using GRADEXPO.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GRADEXPO.Controllers
{
    public class ImageController : Controller
    {
        private readonly IFileService fileService;
        public ImageController(IFileService _fileService)
        {
            fileService = _fileService;
        }
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Show(int id)
        {
            FileFromJson.File file = await fileService.GetFileJsonAsync(id);
            var bytes = Convert.FromBase64String(file.content);
            return File(bytes, "image/jpg");
        }

        public ActionResult AddPhoto(int expoId)
        {
            ImageViewModel imageViewModel = new ImageViewModel()
            {
                expoId = expoId,
                AddButtonTitle = "Загрузить",
                RedirectUrl = Url.Action("DetailsOfExpo", "Expos", new { _idExpo = expoId })
            };
            return View(imageViewModel);
        }

        public async Task<ActionResult> addFile(ImageViewModel imageViewModel)
        {
            FileRepository fileRepository = new FileRepository();
            byte[] bytes;
            if (imageViewModel.photoFile != null)
            {
                using (Stream inputStream = imageViewModel.photoFile.InputStream)
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
                    filename = imageViewModel.photoFile.FileName,
                    fileType = "img",
                    dateTime = DateTimeOffset.Now
                };
                file = await fileRepository.AddFileFromJsonAsync(file);
                ExpoFilesFromJson.ExpoFiles expoFiles = new ExpoFilesFromJson.ExpoFiles()
                {
                    fileId = file.fileId,
                    expoId = imageViewModel.expoId
                };
                ExpoFilesRepository filesRepository = new ExpoFilesRepository();
                await filesRepository.AddExpoFilesFromJsonAsync(expoFiles, "photoExpo");
            }

            return RedirectToLocal(imageViewModel.RedirectUrl);
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