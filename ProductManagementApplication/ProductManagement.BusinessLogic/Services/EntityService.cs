using ProductManagement.BusinessLogic.Interfaces;
using ProductManagement.DataAccess.Entities;

namespace ProductManagement.BusinessLogic.Services
{
    public class EntityService : IEntityService
    {
        public Product CreateProduct(ProductDto entityDTO)
        {
            var entity = MapProductDTOToProductAsync(entityDTO);
            return entity;
        }

        private Product MapProductDTOToProductAsync(ProductDto entityDTO)
        {
            Product product = new Product()
            {
                Name = entityDTO.Name,
                Description = entityDTO.Description,
                Price = entityDTO.Price,
                ProductTypeId = Guid.Parse(entityDTO.ProductTypeId)
            };

            return product;
        }
    }
}
