using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
     public class VendorRepository : IVendorRepository
    {
        async Task<VendorFromJson.Vendor> IVendorRepository.addVendor(VendorFromJson.Vendor _vendor)
        {
            VendorFromJson.Vendor vendor = null;

            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":

                    break;
                case "Json":
                    string json = JsonConvert.SerializeObject(_vendor, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string ret = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVendor), json, "POST");
                    vendor = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VendorFromJson.Vendor>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
                    break;
            }
            return vendor;
        }

        Task IVendorRepository.deleteVender(int _vendorId)
        {
            throw new NotImplementedException();
        }

        async Task<VendorFromJson.Vendor> IVendorRepository.getVendorAsync(int _vendorId)
        {
            VendorFromJson.Vendor vendor = null;

            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":

                    break;
                case "Json":
                    string json = await HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVendor,
                                                                                                             _vendorId));
                    vendor = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VendorFromJson.Vendor>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
                    break;
            }
            return vendor;
        }

        async Task<IEnumerable<VendorFromJson.Vendor>> IVendorRepository.getVendorsAsync()
        {
            List<VendorFromJson.Vendor> vendors = null;

            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":
                    
                    break;
                case "Json":
                    string json = await HttpClient.Browser.GetAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVendor));
                    VendorFromJson.Values rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VendorFromJson.Values>(json));
                    if (rootObject.value == null)
                    {
                        throw new WebException(string.Format("Не удалось получить список всех стендов. Обратитесь к администратору"));
                    }
                    vendors = rootObject.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
                    break;
            }
            return vendors;
        }

        async Task<VendorFromJson.Vendor> IVendorRepository.updateVendor(VendorFromJson.Vendor _vendor)
        {
            VendorFromJson.Vendor vendor = null;

            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "db":

                    break;
                case "Json":
                    string json = JsonConvert.SerializeObject(_vendor, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string ret = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVendor, _vendor.vendorId), json, "PUT");
                    vendor = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VendorFromJson.Vendor>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
                    break;
            }
            return vendor;
        }
    }
}