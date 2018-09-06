using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using GRADEXPO.Repository;

namespace GRADEXPO.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository vendorRepository;

        public VendorService(IVendorRepository _vendorRepository)
        {
            vendorRepository = _vendorRepository;
        }

        async Task<VendorFromJson.Vendor> IVendorService.addVendor(VendorFromJson.Vendor _vendor)
        {
            return await vendorRepository.addVendor(_vendor);
        }

        Task IVendorService.deleteVender(int _vendorId)
        {
            return vendorRepository.deleteVender(_vendorId);
        }

        async Task<VendorFromJson.Vendor> IVendorService.getVendorAsync(int _vendorId)
        {
            return await vendorRepository.getVendorAsync(_vendorId);
        }

        async Task<IEnumerable<VendorFromJson.Vendor>> IVendorService.getVendorsAsync()
        {
            return await vendorRepository.getVendorsAsync();
        }

        async Task<VendorFromJson.Vendor> IVendorService.updateVendor(VendorFromJson.Vendor _vendor)
        {
            return await vendorRepository.updateVendor(_vendor);
        }
    }
}