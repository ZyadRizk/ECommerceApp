using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Interfaces;
using ECommerce.Application.DTOs;

namespace ECommerce.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        // POST: api/admin/products
        [HttpPost("products")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest("Product data is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = created.Id }, created);
        }

        // GET: api/admin/products
        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET: api/admin/products/{id}
        [HttpGet("products/{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // PUT: api/admin/products/{id}
        [HttpPut("products/{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (productDto == null) return BadRequest("Product data is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _productService.UpdateProductAsync(id, productDto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE: api/admin/products/{id}  (soft delete)
        [HttpDelete("products/{id:int}")]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
