using DockerComposeLab1.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerComposeLab1.Data
{
    public class ProductContext : DbContext

    {
        public ProductContext(DbContextOptions options) :base(options) { }
        
        public DbSet<Product> Products { get; set; }
    }
}
