using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }

        [ForeignKey("ProductTypeId")]
        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
