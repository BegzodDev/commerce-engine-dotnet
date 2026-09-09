using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductHandler _handler;
        private readonly GetProductsHandler _getHandler;

        public ProductController(CreateProductHandler handler, GetProductsHandler getHandler)
        {
            _handler = handler;
            _getHandler = getHandler;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var command = new CreateProductCommand
            {

                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };

            var response = await _handler.Handle(command);

            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _getHandler.Handle();

            return Ok(response);
        }
    }
}
