using Microsoft.Extensions.Logging;
using ProductManagement.DataAccess.Entities;
using ProductManagement.DataAccess.Interfaces;
using ProductManagement.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.DataAccess.Repositories
{
    public class ProductRepository(ApplicationDbContext _databaseContext,
        ILogger<ProductRepository> _logger) : IProductRepository
    {
        public async Task AddNewProductAsync(Product product)
        {
            if (product is null)
            {
                _logger.LogError($"Product could not be created: {product}");
                throw new ArgumentNullException($"Product could not be created: {product}");
            }

            await _databaseContext.Products.AddAsync(product);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task AddProductsAsync(List<Product> products)
        {
            await _databaseContext.Products.AddRangeAsync(products);
            await SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            Product productToRemove = await GetProductByIdAsync(id);

            if (productToRemove is null)
            {
                throw new KeyNotFoundException();
            }
            
            _databaseContext.Products.Remove(productToRemove);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            IEnumerable<Product> products = await _databaseContext.Products.Include(pt => pt.ProductType).ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            Product? product = await _databaseContext.Products
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task UpdateProductAsync(Guid id, Product productToUpdate)
        {
            Product product = await GetProductByIdAsync(id);
            product = productToUpdate;
            await _databaseContext.SaveChangesAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

    }
}
