using ProductManagement.DataAccess.Entities;

namespace ProductManagement.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddNewProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
    }
}
