using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface ICityOrMunicipalityRepository
    {
        Task<CityOrMunicipality?> GetByCodeAsync(string code, CancellationToken ct = default);
        Task<CityOrMunicipality?> GetByNameAsync(string name, CancellationToken ct = default);
        Task<IReadOnlyList<CityOrMunicipality>> GetByStateOrRegionCodeAsync(string stateOrRegionCode, CancellationToken ct = default);
        Task<IReadOnlyList<CityOrMunicipality>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(CityOrMunicipality cityOrMunicipality, CancellationToken ct = default);
        Task UpdateAsync(CityOrMunicipality cityOrMunicipality, CancellationToken ct = default);
        Task RemoveAsync(CityOrMunicipality cityOrMunicipality, CancellationToken ct = default);
        Task<bool> ExistsCodeAsync(string code, CancellationToken ct = default);
        Task<IReadOnlyList<CityOrMunicipality>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}