﻿using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Services
{
    public interface IVendorService
    {
        Task<VendorFromJson.Vendor> getVendorAsync(int _vendorId);
        Task<IEnumerable<VendorFromJson.Vendor>> getVendorsAsync();

        Task<VendorFromJson.Vendor> addVendor(VendorFromJson.Vendor _vendor);
        Task<VendorFromJson.Vendor> updateVendor(VendorFromJson.Vendor _vendor);
        Task deleteVender(int _vendorId);
    }
}