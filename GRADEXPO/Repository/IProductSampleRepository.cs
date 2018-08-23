using GRADEXPO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GRADEXPO.Repository
{
    public interface IProductSampleRepository
    {
        Task<ProductSampleFromJson.ProductSample> AddProductSampleAsync(ProductSampleFromJson.ProductSample _productSample);

        Task<IEnumerable<ProductSampleFromJson.ProductSample>> GetProductsSampleAsync(int _productId);
        Task<ProductSampleFromJson.ProductSample> GetProductSampleAsync(int _productId, int _sampleId);

        Task DeleteProductSampleAsync(int _productId, int _sampleId);
    }
}