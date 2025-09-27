using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    }

    
}
