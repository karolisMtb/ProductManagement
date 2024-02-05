using ProductManagement.DataAccess.Entities;

namespace ProductManagement.BusinessLogic.Interfaces
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
        Task<ProductType> GetProductTypeAsync(Guid id);
    }
}
