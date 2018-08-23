using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class ProductFilesRepository : IProductFilesRepository
    {
        public async Task<ProductFilesFromJson.ProductFiles> AddProductFilesAsync(ProductFilesFromJson.ProductFiles _productFiles)
        {
            ProductFilesFromJson.ProductFiles producteFile = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_productFiles, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProductFiles), json, "POST");
                    producteFile = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductFilesFromJson.ProductFiles>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return producteFile;
        }

        public async Task DeleteProductFilesAsync(int _productId, int _fileId)
        {
            throw new NotImplementedException();
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    await GRADEXPO.HttpClient.Browser.DeleteAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetFile,
                                                                                                             _fileId));
                break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }
        }

        public async Task<ProductFilesFromJson.ProductFiles> GetProducteFileAsync(int _productId, int _fileId)
        {
            ProductFilesFromJson.ProductFiles expoFiles = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}(fileId = {2}, productId = {3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetProduct,
                                                                                                             _fileId,
                                                                                                             _productId));
                    expoFiles = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductFilesFromJson.ProductFiles>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return expoFiles;
        }

        public async Task<IEnumerable<ProductFilesFromJson.ProductFiles>> GetProducteFilesAsync(int _productId)
        {
            List< ProductFilesFromJson.ProductFiles> result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetProduct,
                                                                                                             _productId,
                                                                                                             Properties.Settings.Default.postfixGetProductFiles));
                    ProductFilesFromJson.Values producteFilesResult = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductFilesFromJson.Values>(json));
                    result = producteFilesResult.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return result;
        }
    }
}