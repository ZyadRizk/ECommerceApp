using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;



namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CartDto> GetCartAsync(int userId)
        {
            var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
            if (cart == null) return new CartDto { UserId = userId };

            return new CartDto
            {
                UserId = cart.UserId,
                Items = cart.CartItems.Select(ci => new CartItemDto
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.UnitPrice
                }).ToList()
            };
        }

        public async Task<CartDto> AddItemAsync(int userId, int productId, int quantity)
        {
            var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                await _unitOfWork.Carts.AddAsync(cart);
            }

            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null) throw new Exception("Product not found");

            var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (item == null)
            {
                item = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    UnitPrice = product.Price
                };
                cart.CartItems.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }

            await _unitOfWork.SaveChangesAsync();

            return await GetCartAsync(userId);
        }

        public async Task<CartDto> UpdateItemAsync(int userId, int productId, int quantity)
        {
            var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
            if (cart == null) throw new Exception("Cart not found");

            var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (item == null) throw new Exception("Item not found in cart");

            item.Quantity = quantity;
            await _unitOfWork.SaveChangesAsync();

            return await GetCartAsync(userId);
        }

        public async Task<CartDto> RemoveItemAsync(int userId, int productId)
        {
            var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
            if (cart == null) throw new Exception("Cart not found");

            var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (item != null)
            {
                cart.CartItems.Remove(item);
                await _unitOfWork.SaveChangesAsync();
            }

            return await GetCartAsync(userId);
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            var cart = await _unitOfWork.Carts.GetCartWithItemsAsync(userId);
            if (cart == null) return false;

            cart.CartItems.Clear();
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
