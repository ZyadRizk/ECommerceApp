using ECommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    internal interface IUserService
    {
        Task<UserDto> RegisterAsync(UserDto userDto, string password);
        Task<UserDto?> LoginAsync(string username, string password);
        Task<UserDto?> GetByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
    }
}
