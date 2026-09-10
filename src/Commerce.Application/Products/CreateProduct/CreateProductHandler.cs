
using Commerce.Application.Products.Interfaces;
using Commerce.Domain.Entities;
using FluentValidation;

namespace Commerce.Application.Products.CreateProduct
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<CreateProductCommand> _validator;

        public CreateProductHandler(IProductRepository repository, IValidator<CreateProductCommand> validator)
        {
            _repository = repository;
            _validator = validator;

        }


        public async Task<Product> Handle(CreateProductCommand command)
        {
            await _validator.ValidateAsync(command);
            var product = new Product(
            command.Name,
            command.Description,
            command.Price,
            command.Stock);

            await _repository.AddAsync(product);
            return product;
        }
    }
}
