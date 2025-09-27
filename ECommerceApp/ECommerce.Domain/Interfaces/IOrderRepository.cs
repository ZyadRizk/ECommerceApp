using ECommerce.Domain.Entities;



namespace ECommerce.Infrastructure.Repositories
{
    public interface IOrderRepository : IGenericRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetOrdersByUserAsync(int userId);
    }

    
}
