using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Repository
{
    public interface IProductRepository
    {
        Task<ProductFromJson.Product> GetProductAsync(int projectId, int _productId);
        Task<IEnumerable<ProductFromJson.Product>> GetProductsAsync(int _projectId);
        Task<ProductFromJson.Product> AddProductAsync(ProductFromJson.Product _product);
        Task<IEnumerable<ProductFromJson.Product>> GetProductsAsync();
        Task DeleteProductAsync(int projectId, int _productId);
        Task<ProductFromJson.Product> UpdateProductAsync(ProductFromJson.Product _product);
    }
}