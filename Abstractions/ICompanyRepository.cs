using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface ICompanyRepository
    {
        Task<Company?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<Company?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<Company?> GetByEmailAsync(string email, CancellationToken ct = default);
        Task<IReadOnlyList<Company>> GetByCityIdAsync(string cityId, CancellationToken ct = default);
        Task<IReadOnlyList<Company>> GetByCategoryIdAsync(int categoryId, CancellationToken ct = default);
        Task<IReadOnlyList<Company>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Company company, CancellationToken ct = default);
        Task UpdateAsync(Company company, CancellationToken ct = default);
        Task RemoveAsync(Company company, CancellationToken ct = default);
        Task<bool> ExistsIdAsync(string id, CancellationToken ct = default);
        Task<IReadOnlyList<Company>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}