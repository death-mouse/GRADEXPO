using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class VendorContactsRepository : IVendorContactsRepository
    {
        public async Task<VendorContactsFromJson.VendorContacts> addVendorContact(VendorContactsFromJson.VendorContacts _vendorContacts)
        {
            VendorContactsFromJson.VendorContacts vendorContacts = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_vendorContacts, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}({2})/{3}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetVendor, _vendorContacts.vendorId, Properties.Settings.Default.postfixGetVendorContacts), json, "POST");
                    vendorContacts = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VendorContactsFromJson.VendorContacts>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return vendorContacts;
        }

        public async Task deleteVendorContact(int _contactId)
        {
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    await GRADEXPO.HttpClient.Browser.DeleteAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVendorContacts,
                                                                                                             _contactId));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }
        }

        public async Task<VendorContactsFromJson.VendorContacts> getVendorContact(int _vendorId, int _contactId)
        {
            VendorContactsFromJson.VendorContacts vendorContacts = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":

                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3}({4})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVendor,
                                                                                                             _vendorId,
                                                                                                             Properties.Settings.Default.postfixGetVendorContacts,
                                                                                                             _contactId));
                    vendorContacts = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VendorContactsFromJson.VendorContacts>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return vendorContacts;
        }

        public  async Task<IEnumerable<VendorContactsFromJson.VendorContacts>> getVendorContacts(int _vendorId)
        {
            List<VendorContactsFromJson.VendorContacts> result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3}", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVendor,
                                                                                                             _vendorId,
                                                                                                             Properties.Settings.Default.postfixGetVendorContacts));
                    VendorContactsFromJson.Values vendorContacts = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VendorContactsFromJson.Values>(json));
                    result = vendorContacts.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return result;
        }

        public async Task<VendorContactsFromJson.VendorContacts> updateVendorContact(VendorContactsFromJson.VendorContacts _vendorContacts)
        {
            VendorContactsFromJson.VendorContacts result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_vendorContacts, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string ret = await GRADEXPO.HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}({2})/{3}({4})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetVendor,
                                                                                                             _vendorContacts.vendorId,
                                                                                                             Properties.Settings.Default.postfixGetVendorContacts,
                                                                                                             _vendorContacts.contactId), json, "PUT");
                    result = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<VendorContactsFromJson.VendorContacts>(ret));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return result;
        }
    }
}