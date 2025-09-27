using ECommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> PlaceOrderAsync(int userId, string shippingAddress, string paymentMethod);
        Task<IEnumerable<OrderDto>> GetOrdersByUserAsync(int userId);
        Task<OrderDto?> GetOrderByIdAsync(int orderId);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}
