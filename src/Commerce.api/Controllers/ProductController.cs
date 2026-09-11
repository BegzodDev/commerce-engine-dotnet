using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.GetProducts;
using Commerce.Application.Products.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductHandler _handler;
        private readonly GetProductsHandler _getHandler;
        private readonly UpdateProductHandler _updateHandler;

        public ProductController(CreateProductHandler handler, GetProductsHandler getHandler, UpdateProductHandler updateHandler)
        {
            _handler = handler;
            _getHandler = getHandler;
            _updateHandler = updateHandler;
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


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductRequest request)
        {
            var command = new UpdateProductCommand
            {
                Id = id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            var response = await _updateHandler.Handle(command);
            return response is null ? NotFound() : Ok(response);
        }

    }
}
