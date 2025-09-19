using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface ICountryRepository
    {
        Task<Country?> GetByIsoCodeAsync(string isoCode, CancellationToken ct = default);
        Task<Country?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Country country, CancellationToken ct = default);
        Task UpdateAsync(Country country, CancellationToken ct = default);
        Task RemoveAsync(Country country, CancellationToken ct = default);
        Task<bool> ExistsIsoCodeAsync(string isoCode, CancellationToken ct = default);
        Task<IReadOnlyList<Country>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}