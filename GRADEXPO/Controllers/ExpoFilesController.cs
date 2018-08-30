using GRADEXPO.Services;
using GRADEXPO.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GRADEXPO.Models;

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
    }
}