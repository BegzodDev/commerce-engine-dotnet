using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.DeactivateProduct;
using Commerce.Application.Products.GetProducts;
using Commerce.Application.Products.UpdateProduct;
using Commerce.Application.Products.UpdateStock;
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
        private readonly UpdateStockHandler _updateStockHandler;
        private readonly DeactivateProductHandler _deactivateProductHandler;

        public ProductController(
                CreateProductHandler handler,
                GetProductsHandler getHandler,
                UpdateProductHandler updateHandler,
                UpdateStockHandler updateStockHandler,
                DeactivateProductHandler deactivateProductHandler)
        {
            _handler = handler;
            _getHandler = getHandler;
            _updateHandler = updateHandler;
            _updateStockHandler = updateStockHandler;
            _deactivateProductHandler = deactivateProductHandler;
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

        [HttpPatch("{id:guid}/stock")]
        public async Task<IActionResult> UpdateStock(Guid id, UpdateStockCommand command)
        {
            command.ProductId = id;
            var response = await _updateStockHandler.Handle(command);

            if (response is null) return NotFound();

            return Ok(response);
        }

        [HttpPatch("{id:guid}/deactivate")]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var command = new DeactivateProductCommand { Id = id };

            var response = await _deactivateProductHandler.Handle(command);

            if (response is null) return NotFound();

            return Ok(response);
        }

    }
}
