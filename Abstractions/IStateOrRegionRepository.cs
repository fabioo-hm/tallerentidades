using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IStateOrRegionRepository
    {
        Task<StateOrRegion?> GetByCodeAsync(string code, CancellationToken ct = default);
        Task<StateOrRegion?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<StateOrRegion?> GetByCode3166Async(string code3166, CancellationToken ct = default);
        Task<IReadOnlyList<StateOrRegion>> GetByCountryIsoCodeAsync(string countryIsoCode, CancellationToken ct = default);
        Task<IReadOnlyList<StateOrRegion>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(StateOrRegion stateOrRegion, CancellationToken ct = default);
        Task UpdateAsync(StateOrRegion stateOrRegion, CancellationToken ct = default);
        Task RemoveAsync(StateOrRegion stateOrRegion, CancellationToken ct = default);
        Task<bool> ExistsCodeAsync(string code, CancellationToken ct = default);
        Task<IReadOnlyList<StateOrRegion>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}