using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // all cart actions require login
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // helper to get userId from JWT
        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var userId = GetUserId();
            var cart = await _cartService.GetCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost("add")]
        public async Task<ActionResult<CartDto>> AddItem(int productId, int quantity)
        {
            var userId = GetUserId();
            var cart = await _cartService.AddItemAsync(userId, productId, quantity);
            return Ok(cart);
        }

        [HttpPut("update")]
        public async Task<ActionResult<CartDto>> UpdateItem(int productId, int quantity)
        {
            var userId = GetUserId();
            var cart = await _cartService.UpdateItemAsync(userId, productId, quantity);
            return Ok(cart);
        }

        [HttpDelete("remove")]
        public async Task<ActionResult<CartDto>> RemoveItem(int productId)
        {
            var userId = GetUserId();
            var cart = await _cartService.RemoveItemAsync(userId, productId);
            return Ok(cart);
        }

        [HttpDelete("clear")]
        public async Task<ActionResult> ClearCart()
        {
            var userId = GetUserId();
            var success = await _cartService.ClearCartAsync(userId);

            if (!success) return BadRequest("Cart could not be cleared.");
            return NoContent();
        }
    }
}
