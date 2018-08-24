using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;

namespace GRADEXPO.Repository
{
    public class VendorRepository : IVendorRepository
    {
        Task<VendorFromJson.Vendor> IVendorRepository.addVendor(VendorFromJson.Vendor _vendor)
        {
            throw new NotImplementedException();
        }

        Task IVendorRepository.deleteVender(int _vendorId)
        {
            throw new NotImplementedException();
        }

        Task<VendorFromJson.Vendor> IVendorRepository.getVendorAsync(int _vendorId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<VendorFromJson.Vendor>> IVendorRepository.getVendorsAsync()
        {
            throw new NotImplementedException();
        }

        Task<VendorFromJson.Vendor> IVendorRepository.updateVendor(VendorFromJson.Vendor _vendor)
        {
            throw new NotImplementedException();
        }
    }
}