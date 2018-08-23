using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class ProductSampleRepository : IProductSampleRepository
    {
        public async Task<ProductSampleFromJson.ProductSample> AddProductSampleAsync(ProductSampleFromJson.ProductSample _productSample)
        {
            ProductSampleFromJson.ProductSample productSample = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_productSample, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProductSample), json, "POST");
                    productSample = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductSampleFromJson.ProductSample>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return productSample;
        }

        public Task DeleteProductSampleAsync(int _productId, int _sampleId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductSampleFromJson.ProductSample> GetProductSampleAsync(int _productId, int _sampleId)
        {
            ProductSampleFromJson.ProductSample productSample = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}(_sampleId = {2}, productId = {3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetProductSample,
                                                                                                             _sampleId,
                                                                                                             _productId));
                    productSample = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductSampleFromJson.ProductSample>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return productSample;
        }

        public async Task<IEnumerable<ProductSampleFromJson.ProductSample>> GetProductsSampleAsync(int _productId)
        {
            List<ProductSampleFromJson.ProductSample> result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetProduct,
                                                                                                             _productId,
                                                                                                             Properties.Settings.Default.postfixGetProductFiles));
                    ProductSampleFromJson.Values producteFilesResult = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductSampleFromJson.Values>(json));
                    result = producteFilesResult.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return result;
        }
    }
}