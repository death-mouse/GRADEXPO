using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class ProductRepository : IProductRepository
    {
        public async Task<ProductFromJson.Product> AddProductAsync(ProductFromJson.Product _product)
        {
            ProductFromJson.Product product = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_product, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProduct), json, "POST");
                    product = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductFromJson.Product>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return product;
        }

        public async Task DeleteProductAsync(int projectId, int _productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductFromJson.Product> GetProductAsync(int projectId, int _productId)
        {
            ProductFromJson.Product product = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}(projectId = {2}, productId = {3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetProduct,
                                                                                                             projectId,
                                                                                                             _productId));
                    product = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductFromJson.Product>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return product;
        }

        public async Task<IEnumerable<ProductFromJson.Product>> GetProductsAsync(int _projectId)
        {
            List<ProductFromJson.Product> result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})/{3})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetProject,
                                                                                                             _projectId,
                                                                                                             Properties.Settings.Default.postfixGetProduct));
                    ProductFromJson.Values expoFilesResult = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductFromJson.Values>(json));
                    result = expoFilesResult.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return result;
        }

        public async Task<IEnumerable<ProductFromJson.Product>> GetProductsAsync()
        {
            List<ProductFromJson.Product> result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await GRADEXPO.HttpClient.Browser.GetAsync(string.Format("{0}{1})", Properties.Settings.Default.BaseUrlApi,
                                                                                                             Properties.Settings.Default.postfixGetProduct));
                    ProductFromJson.Values expoFilesResult = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductFromJson.Values>(json));
                    result = expoFilesResult.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return result;
        }

        public async Task<ProductFromJson.Product> UpdateProductAsync(ProductFromJson.Product _product)
        {
            ProductFromJson.Product product = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = JsonConvert.SerializeObject(_product, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProduct, _product.productId), json, "PUT");
                    product = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProductFromJson.Product>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return product;
        }
    }
}