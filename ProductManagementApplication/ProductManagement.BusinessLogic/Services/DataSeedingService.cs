using ProductManagement.BusinessLogic.Interfaces;
using ProductManagement.DataAccess.Entities;
using ProductManagement.DataAccess.Interfaces;

namespace ProductManagement.BusinessLogic.Services
{
    public class DataSeedingService : IDataSeedingService
    {
        public readonly List<Product> _products = [];
        public readonly List<ProductType> _productTypes = [];
        private readonly IDataSeedingRepository _dataSeedingRepository;

        public DataSeedingService(IDataSeedingRepository dataSeedingRepository)
        {
            _dataSeedingRepository = dataSeedingRepository;
            GetMockData();
        }

        public async Task SeedInitialDataAsync()
        {
            await _dataSeedingRepository.SeedInitialDataAsync(_products, _productTypes);
        }

        //tobulinti
        private void GetMockData()
        {
            var productType1 = new ProductType
            {
                Id = Guid.NewGuid(),
                TypeName = "Electronics"
            };

            var productType2 = new ProductType
            {
                Id = Guid.NewGuid(),
                TypeName = "Clothing"
            };

            _productTypes.Add(productType1);
            _productTypes.Add(productType2);

            var product1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                Description = "Powerful laptop for work",
                Price = 999.99,
                ProductTypeId = productType1.Id
            };

            var product2 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "T-shirt",
                Description = "Comfortable cotton T-shirt",
                Price = 19.99,
                ProductTypeId = productType2.Id
            };

            var product3 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Smartphone",
                Description = "High-end smartphone",
                Price = 799.99,
                ProductTypeId = productType1.Id
            };

            _products.Add(product1);
            _products.Add(product2);
            _products.Add(product3);

        }
    }
}
