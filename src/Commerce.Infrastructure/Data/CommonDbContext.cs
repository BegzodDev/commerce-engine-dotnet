using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Data
{
    public class CommonDbContext : DbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
    }
}
