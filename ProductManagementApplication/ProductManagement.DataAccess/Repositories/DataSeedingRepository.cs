using Microsoft.Extensions.Logging;
using ProductManagement.DataAccess.DatabaseContext;
using ProductManagement.DataAccess.Entities;
using ProductManagement.DataAccess.Interfaces;

namespace ProductManagement.DataAccess.Repositories
{
    public class DataSeedingRepository(ApplicationDbContext _databaseContext,
        ILogger<ProductRepository> _logger, IProductTypeRepository _productTypeRepository, IProductRepository _productRepository) : IDataSeedingRepository
    {
        private async Task ClearDatabaseAsync()
        {
            _databaseContext.Products.RemoveRange(_databaseContext.Products);
            _databaseContext.ProductTypes.RemoveRange(_databaseContext.ProductTypes);
            await SaveChangesAsync();
        }
        public async Task SeedInitialDataAsync(List<Product> products, List<ProductType> productTypes)
        {
            try
            {
                await ClearDatabaseAsync();
                await _productTypeRepository.AddProductTypesAsync(productTypes);
                await _productRepository.AddProductsAsync(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Database seeding failed. Error occurred: {ex.Message}");
            }
        }

        private async Task SaveChangesAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

    }
}
