using Commerce.Application.Products.Interfaces;

namespace Commerce.Application.Products.GetProducts
{
    public class GetProductsHandler
    {
        private readonly IProductRepository _repository;
        public GetProductsHandler(IProductRepository repos)
        {
            _repository = repos;
        }
        public async Task<List<GetProductResponse>> Handle()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(product => new GetProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            }).ToList();
        }
    }
}
