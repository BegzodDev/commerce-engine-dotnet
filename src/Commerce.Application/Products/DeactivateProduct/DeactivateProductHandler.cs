using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.Interfaces;

namespace Commerce.Application.Products.DeactivateProduct
{
    public class DeactivateProductHandler
    {
        private readonly IProductRepository _repos;
        public DeactivateProductHandler(IProductRepository repos)
        {
            _repos = repos;
        }

        public async Task<CreateProductResponse> Handle(DeactivateProductCommand command)
        {
            var product = await _repos.GetByIdAsync(command.Id);

            if (product is null) return null;

            product.Deactivate();
            await _repos.UpdateAsync(product);

            return new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt,
            };
        }
    }
}
