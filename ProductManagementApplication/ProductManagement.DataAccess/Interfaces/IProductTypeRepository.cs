using ProductManagement.DataAccess.Entities;

namespace ProductManagement.DataAccess.Interfaces
{
    public interface IProductTypeRepository
    {
        Task AddProductTypesAsync(List<ProductType> productTypes);
        Task<ProductType> GetProductTypeByIdAsync(Guid guid);
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
    }
}
