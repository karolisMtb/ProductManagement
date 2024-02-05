using ProductManagement.BusinessLogic.Interfaces;
using ProductManagement.DataAccess.Entities;
using ProductManagement.DataAccess.Interfaces;

namespace ProductManagement.BusinessLogic.Services
{
    public class ProductTypeService(IProductTypeRepository _productTypeRepository) : IProductTypeService
    {
        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            var productTypes = await _productTypeRepository.GetProductTypesAsync();
            return productTypes;
        }

        public async Task<ProductType> GetProductTypeAsync(Guid id)
        {
            var productType = await _productTypeRepository.GetProductTypeByIdAsync(id);
            return productType;
        }
    }
}
