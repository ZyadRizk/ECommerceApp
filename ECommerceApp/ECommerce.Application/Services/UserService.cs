using ECommerce.Application.DTOs;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> RegisterAsync(UserDto userDto, string password)
        {
            var user = new User
            {
                Email = userDto.Email,
                UserName = userDto.Username,
                Password = password,
                Status = Domain.Enums.UserRole.Customer
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            userDto.Id = user.Id;
            return userDto;
        }

        public async Task<UserDto?> LoginAsync(string username, string password)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(username);

            if (user == null || user.Password != password)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Role = user.Status.ToString()
            };
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Role = user.Status.ToString()
            };
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                Username = u.UserName,
                Role = u.Status.ToString()
            });
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return false;

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
