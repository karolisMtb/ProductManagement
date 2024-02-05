using ProductManagement.DataAccess.Entities;

namespace ProductManagement.DataAccess.Interfaces
{
    public interface IDataSeedingRepository
    {
        Task SeedInitialDataAsync(List<Product> products, List<ProductType> productTypes);
    }
}
