using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Repository
{
    public interface IProductFilesRepository
    {
        Task<ProductFilesFromJson.ProductFiles> AddProductFilesAsync(ProductFilesFromJson.ProductFiles _productFiles);

        Task<IEnumerable<ProductFilesFromJson.ProductFiles>> GetProducteFilesAsync(int _productId);
        Task<ProductFilesFromJson.ProductFiles> GetProducteFileAsync(int _productId, int _fileId);

        Task DeleteProductFilesAsync(int _productId, int _fileId);
    }
}