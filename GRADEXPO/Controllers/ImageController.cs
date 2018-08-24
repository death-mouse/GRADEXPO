using GRADEXPO.Models;
using GRADEXPO.Services;
using System;
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
    }
}