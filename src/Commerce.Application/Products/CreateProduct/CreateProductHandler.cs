
using Commerce.Application.Products.Interfaces;
using Commerce.Domain.Entities;

namespace Commerce.Application.Products.CreateProduct
{
    public class CreateProductHandler
    {
        /// <summary>
        /// Handler ishlashi uchun menga IProductRepository kerak (yani pasidagi qismi)
        /// </summary>
        private readonly IProductRepository _repository;


        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task<Product> Handle(CreateProductCommand command)
        {
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
