using Commerce.Application.Products.CreateProduct;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var product = await _handler.Handle(command);
            return Ok(product);
        }
    }
}
