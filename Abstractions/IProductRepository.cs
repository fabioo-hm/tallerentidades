using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<Product>> GetByNameAsync(string name, CancellationToken ct = default);
        Task<IReadOnlyList<Product>> GetByCategoryIdAsync(int categoryId, CancellationToken ct = default);
        Task<IReadOnlyList<Product>> GetByTypeProductIdAsync(int typeProductId, CancellationToken ct = default);
        Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Product product, CancellationToken ct = default);
        Task UpdateAsync(Product product, CancellationToken ct = default);
        Task RemoveAsync(Product product, CancellationToken ct = default);
        Task<bool> ExistsIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<Product>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}