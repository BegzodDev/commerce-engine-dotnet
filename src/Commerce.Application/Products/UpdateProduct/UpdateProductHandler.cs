using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.Interfaces;
using System.Collections;
using System.Xml.Linq;

namespace Commerce.Application.Products.UpdateProduct
{
    public class UpdateProductHandler
    {
        public readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repos)
        {
            _repository = repos;
        }

        public async Task<CreateProductResponse?> Handle(UpdateProductCommand command)
        {
            var product = await _repository.GetByIdAsync(command.Id);

            if (product == null)
                return null;
            product.UpdateInformation(command.Name, command.Description);
            product.ChangePrice(command.Price);

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
            }
            ;

        }
    }
}
