using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.Interfaces;

namespace Commerce.Application.Products.UpdateStock
{
    public class UpdateStockHandler
    {
        private readonly IProductRepository _repository;

        public UpdateStockHandler(IProductRepository repos)
        {
            _repository = repos;
        }

        public async Task<CreateProductResponse?> Handle(UpdateStockCommand command)
        {
            var product = await _repository.GetByIdAsync(command.ProductId);

            if (product == null) return null;

            if (command.Increase)
                product.IncreaseStock(command.Quantity);
            else
                product.DecreaseStock(command.Quantity);

            await _repository.UpdateAsync(product);

            return new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            };
        }
    }
}
