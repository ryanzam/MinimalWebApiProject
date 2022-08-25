using Microsoft.EntityFrameworkCore;
using MinimalWebApiProject.Models;

namespace MinimalWebApiProject.Data
{    
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> opts): base(opts){ }

        public DbSet<Product> Products => Set<Product>();
    }
}