using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement.DataAccess.DatabaseContext;
using ProductManagement.DataAccess.Entities;
using ProductManagement.DataAccess.Interfaces;

namespace ProductManagement.DataAccess.Repositories
{
    public class ProductTypeRepository(ApplicationDbContext _databaseContext,
        ILogger<ProductRepository> _logger) : IProductTypeRepository
    {
        public async Task AddProductTypesAsync(List<ProductType> productTypes)
        {
            await _databaseContext.ProductTypes.AddRangeAsync(productTypes);
            await SaveChangesAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(Guid guid)
        {
            var productType = await _databaseContext.ProductTypes.Where(x => x.Id == guid).FirstOrDefaultAsync();
            
            if(productType == null)
            {
                throw new KeyNotFoundException();
            }

            return productType;
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            List<ProductType> productTypes = await _databaseContext.ProductTypes.ToListAsync();
            return productTypes;
        }

        private async Task SaveChangesAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
