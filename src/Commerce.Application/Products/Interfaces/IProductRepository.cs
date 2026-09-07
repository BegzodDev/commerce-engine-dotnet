using Commerce.Domain.Entities;

namespace Commerce.Application.Products.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
    }
}
