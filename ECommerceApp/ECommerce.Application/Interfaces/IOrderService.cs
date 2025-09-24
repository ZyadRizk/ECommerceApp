using ECommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    internal interface IOrderService
    {
        Task<OrderDto> PlaceOrderAsync(int userId);
        Task<IEnumerable<OrderDto>> GetOrdersByUserAsync(int userId);
        Task<OrderDto?> GetOrderByIdAsync(int orderId);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}
