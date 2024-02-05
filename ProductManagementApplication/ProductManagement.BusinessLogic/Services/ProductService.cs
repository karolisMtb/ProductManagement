using Microsoft.Extensions.Logging;
using ProductManagement.BusinessLogic.Interfaces;
using ProductManagement.DataAccess.Entities;
using ProductManagement.DataAccess.Interfaces;

namespace ProductManagement.BusinessLogic.Services
{
    public class ProductService(IProductRepository _productRepository, IProductTypeRepository _productTypeRepository,
        ILogger<ProductService> _logger) : IProductService
    {

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            IEnumerable<Product> products = await _productRepository.GetAllProductsAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            Product product = await _productRepository.GetProductByIdAsync(id);
            
            if (product == null)
            {
                _logger.LogError($"Product with give id {id.ToString()} could not be found");
            }
            
            return product;
        }

        public async Task AddNewProductAsync(Product product)
        {
            await _productRepository.AddNewProductAsync(product);
        }
    }
}
