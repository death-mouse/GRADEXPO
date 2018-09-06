using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using GRADEXPO.Repository;

namespace GRADEXPO.Services
{
    public class VendorContactsService : IVendorContactsService
    {
        private readonly IVendorContactsRepository vendorContactsRepository;

        public VendorContactsService(IVendorContactsRepository _vendorContactsRepository)
        {
            vendorContactsRepository = _vendorContactsRepository;
        }
        public async Task<VendorContactsFromJson.VendorContacts> addVendorContact(VendorContactsFromJson.VendorContacts _vendorContacts)
        {
            return await vendorContactsRepository.addVendorContact(_vendorContacts);
        }

        public Task deleteVendorContact(int _contactId)
        {
            return vendorContactsRepository.deleteVendorContact(_contactId);
        }

        public async Task<VendorContactsFromJson.VendorContacts> getVendorContact(int _vendorId, int _contactId)
        {
            return await vendorContactsRepository.getVendorContact(_vendorId, _contactId);
        }

        public async Task<IEnumerable<VendorContactsFromJson.VendorContacts>> getVendorContacts(int _vendorId)
        {
            return await vendorContactsRepository.getVendorContacts(_vendorId);
        }

        public async Task<VendorContactsFromJson.VendorContacts> updateVendorContact(VendorContactsFromJson.VendorContacts _vendorContacts)
        {
            return await vendorContactsRepository.updateVendorContact(_vendorContacts);
        }
    }
}