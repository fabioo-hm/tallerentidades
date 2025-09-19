using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IAudienceRepository
    {
        Task<Audience?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Audience?> GetByDescriptionAsync(string description, CancellationToken ct = default);
        Task<IReadOnlyList<Audience>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Audience audience, CancellationToken ct = default);
        Task UpdateAsync(Audience audience, CancellationToken ct = default);
        Task RemoveAsync(Audience audience, CancellationToken ct = default);
        Task<bool> ExistsIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<Audience>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}