
namespace ProductManagement.DataAccess.Entities
{
    public class ProductType
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public List<Product>? Products { get; set; }
    }
}
