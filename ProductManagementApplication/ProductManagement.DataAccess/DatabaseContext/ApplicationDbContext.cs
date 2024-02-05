using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.Entities;

namespace ProductManagement.DataAccess.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

    }
}
