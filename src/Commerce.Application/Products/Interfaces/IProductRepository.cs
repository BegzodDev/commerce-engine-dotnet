using Commerce.Domain.Entities;

namespace Commerce.Application.Products.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task UpdateAsync(Product product);
    }
}
