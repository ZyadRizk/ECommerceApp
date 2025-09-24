using ECommerce.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces
{
    internal interface IProductService
    {
        Task<ProductDto> AddProductAsync(ProductDto productDto);
        Task<ProductDto> UpdateProductAsync(ProductDto productDto);
        Task<bool> DeleteProductAsync(int id);
        Task<ProductDto?> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
    }
}
