using GRADEXPO.Models;
using GRADEXPO.Repository;
using GRADEXPO.Services;
using GRADEXPO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GRADEXPO.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorService vendorService;
        public VendorController(IVendorService _vendorService)
        {
            vendorService = _vendorService;
        }
        // GET: Vendor
        public async  Task<ActionResult> Index()
        {
            IEnumerable<VendorFromJson.Vendor> vendors = await vendorService.getVendorsAsync();
            return View(vendors);
        }

        public async Task<ActionResult> DetailAboutVendor(int vendorId)
        {
            VendorFromJson.Vendor vendor = await vendorService.getVendorAsync(vendorId);
            return View(vendor);
        }


        public async Task<ActionResult> EditVendor(int vendorId)
        {
            var vendorViewModel = new VendorViewModel();
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":

                    break;
                case "Json":
                    var vendor = await vendorService.getVendorAsync(vendorId);
                    vendorViewModel = new VendorViewModel
                    {
                        Title = "Изменение поставщика",
                        AddButtonTitle = "Сохранить",
                        RedirectUrl = Url.Action("DetailAboutVendor", "Vendor", new { vendorId = vendorId }),
                        description = vendor.description,
                        vendAccount = vendor.vendAccount,
                        vendorId = vendor.vendorId,
                        vendorName = vendor.vendorName
                    };
                    break;

            }

            return View(vendorViewModel);
        }

        public async Task<ActionResult> Update(VendorViewModel vendorViewModel)
        {
            VendorFromJson.Vendor vendor = new VendorFromJson.Vendor()
            {
                vendorId = vendorViewModel.vendorId,
                description = vendorViewModel.description,
                vendAccount = vendorViewModel.vendAccount,
                vendorName = vendorViewModel.vendorName
            };

            await vendorService.updateVendor(vendor);
            return RedirectToLocal(vendorViewModel.RedirectUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Add()
        {
            var vendorViewModel = new VendorViewModel
            {
                Title = "Создание нового поставщика",
                AddButtonTitle = "Создать",
                RedirectUrl = Url.Action("Index", "Vendor")
            };
            return View(vendorViewModel);
        }
        public async Task<ActionResult> AddNew(VendorViewModel vendorViewModel)
        {
            VendorFromJson.Vendor vendor = new VendorFromJson.Vendor()
            {
                description = vendorViewModel.description,
                vendAccount = vendorViewModel.vendAccount,
                vendorName = vendorViewModel.vendorName
            };
            await vendorService.addVendor(vendor);
            return RedirectToLocal(vendorViewModel.RedirectUrl);
        }
    }
}