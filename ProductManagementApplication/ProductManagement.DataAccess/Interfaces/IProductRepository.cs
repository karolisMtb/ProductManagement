using ProductManagement.DataAccess.Entities;

namespace ProductManagement.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddNewProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
        Task UpdateProductAsync(Guid id, Product productToUpdate);
        Task AddProductsAsync(List<Product> products);
    }
}
