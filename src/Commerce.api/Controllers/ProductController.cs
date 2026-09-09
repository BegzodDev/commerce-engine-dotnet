using Commerce.Application.Products.CreateProduct;
using Commerce.Application.Products.Interfaces;
using Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Commerce.api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductHandler _handler;

        public ProductController(CreateProductHandler handler)
        {
            _handler = handler;
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
    }
}
