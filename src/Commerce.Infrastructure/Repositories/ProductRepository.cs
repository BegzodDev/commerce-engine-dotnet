using Commerce.Application.Products.Interfaces;
using Commerce.Domain.Entities;
using Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CommonDbContext _context;
        public ProductRepository(CommonDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task<Product> GetByIdAsync(Guid Id)
        {
            return await _context.Products.FirstOrDefaultAsync(x=>x.Id == Id);
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
