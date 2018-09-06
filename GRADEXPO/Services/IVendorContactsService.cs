using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Services
{
    public interface IVendorContactsService
    {
        Task<VendorContactsFromJson.VendorContacts> getVendorContact(int _vendorId, int _contactId);
        Task<IEnumerable<VendorContactsFromJson.VendorContacts>> getVendorContacts(int _vendorId);

        Task<VendorContactsFromJson.VendorContacts> addVendorContact(VendorContactsFromJson.VendorContacts _vendorContacts);
        Task<VendorContactsFromJson.VendorContacts> updateVendorContact(VendorContactsFromJson.VendorContacts _vendorContacts);

        Task deleteVendorContact(int _contactId);
    }
}