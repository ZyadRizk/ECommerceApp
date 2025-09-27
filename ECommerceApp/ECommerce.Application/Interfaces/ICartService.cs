using ECommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartDto> GetCartAsync(int userId);
        Task<CartDto> AddItemAsync(int userId, int productId, int quantity);
        Task<CartDto> UpdateItemAsync(int userId, int productId, int quantity);
        Task<CartDto> RemoveItemAsync(int userId, int productId);
        Task<bool> ClearCartAsync(int userId);
    }
}
