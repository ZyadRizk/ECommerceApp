using ECommerce.Domain.Entities;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> GetCartWithItemsAsync(int userId);
    }
}
