using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IFavoriteRepository
    {
        Task<Favorite?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<Favorite>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Favorite favorite, CancellationToken ct = default);
        Task UpdateAsync(Favorite favorite, CancellationToken ct = default);
        Task RemoveAsync(Favorite favorite, CancellationToken ct = default);
        Task<IReadOnlyList<Favorite>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
        Task<IReadOnlyList<Favorite>> GetByCustomerAsync(int customerId, CancellationToken ct = default);
        Task<IReadOnlyList<Favorite>> GetByCompanyAsync(string companyId, CancellationToken ct = default);
    }
}