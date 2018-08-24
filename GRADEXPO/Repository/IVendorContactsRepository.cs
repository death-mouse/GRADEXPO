using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public interface IVendorContactsRepository
    {
        Task<VendorContactsFromJson.VendorContacts> getVendorContact(int _vendorId, int _contactId);
        Task<IEnumerable<VendorContactsFromJson.VendorContacts>> getVendorContacts(int _vendorId);

        Task<VendorContactsFromJson.VendorContacts> addVendorContact(VendorContactsFromJson.VendorContacts _vendorContacts);
        Task<VendorContactsFromJson.VendorContacts> updateVendorContact(VendorContactsFromJson.VendorContacts _vendorContacts);

        Task deleteVendorContact(int _contactId);
    }
}