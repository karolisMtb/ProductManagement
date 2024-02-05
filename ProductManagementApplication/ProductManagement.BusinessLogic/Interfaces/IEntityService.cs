using ProductManagement.DataAccess.Entities;

namespace ProductManagement.BusinessLogic.Interfaces
{
    public interface IEntityService
    {
        Product CreateProduct(ProductDto entityDTO);
    }
}
