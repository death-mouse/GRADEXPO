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
    public class VendorContactController : Controller
    {
        IVendorContactsService vendorContactsService;
        public VendorContactController(IVendorContactsService _vendorContactsService)
        {
            vendorContactsService = _vendorContactsService;
        }
        // GET: VendorContact
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> VendorContacts(int vendorId)
        {
            IEnumerable<VendorContactsFromJson.VendorContacts> vendorContacts = await vendorContactsService.getVendorContacts(vendorId);
            return PartialView(vendorContacts);
        }

        public ActionResult Add(int vendorId)
        {
            var vendorContactViewModel = new VendorContactViewModel()
            {
                AddButtonTitle = "Создать",
                RedirectUrl = Url.Action("DetailAboutVendor", "Vendor", new { vendorId }),
                vendorId = vendorId
            };

            return View(vendorContactViewModel);
        }

        public async Task<ActionResult> AddNew(VendorContactViewModel vendorContactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(vendorContactViewModel);
            }
            VendorContactsFromJson.VendorContacts vendorContacts = new VendorContactsFromJson.VendorContacts()
            {
                contactPerson = vendorContactViewModel.contactPerson,
                contactPosition = vendorContactViewModel.contactPosition,
                description = vendorContactViewModel.description,
                email = vendorContactViewModel.email,
                im = vendorContactViewModel.im,
                phone = vendorContactViewModel.phone,
                vendorId = vendorContactViewModel.vendorId
            };

            await vendorContactsService.addVendorContact(vendorContacts);

            return RedirectToLocal(vendorContactViewModel.RedirectUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> UpdateContact(int vendorId, int contactId)
        {

            VendorContactsFromJson.VendorContacts vendorContacts = await vendorContactsService.getVendorContact(vendorId, contactId);
            var vendorContactViewModel = new VendorContactViewModel()
            {
                AddButtonTitle = "Изменить",
                RedirectUrl = Url.Action("DetailAboutVendor", "Vendor", new { vendorContacts.vendorId }),
                vendorId = vendorContacts.vendorId,
                contactId = vendorContacts.contactId,
                contactPerson = vendorContacts.contactPerson,
                contactPosition = vendorContacts.contactPosition,
                description = vendorContacts.description,
                email = vendorContacts.email,
                im = vendorContacts.im,
                phone = vendorContacts.phone
            };

            return View(vendorContactViewModel);
        }

        public async Task<ActionResult> Save(VendorContactViewModel vendorContactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(vendorContactViewModel);
            }
            VendorContactsFromJson.VendorContacts vendorContacts = new VendorContactsFromJson.VendorContacts()
            {
                contactId = vendorContactViewModel.contactId,
                vendorId = vendorContactViewModel.vendorId,
                phone = vendorContactViewModel.phone,
                im = vendorContactViewModel.im,
                contactPerson = vendorContactViewModel.contactPerson,
                contactPosition = vendorContactViewModel.contactPosition,
                description = vendorContactViewModel.description,
                email = vendorContactViewModel.email
            };
            await vendorContactsService.updateVendorContact(vendorContacts);
            return RedirectToLocal(vendorContactViewModel.RedirectUrl);
        }
    }
}