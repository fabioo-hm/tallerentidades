using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface ISubdivisionCategoryRepository
    {
        Task<SubdivisionCategory?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<SubdivisionCategory>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(SubdivisionCategory subdivisionCategory, CancellationToken ct = default);
        Task UpdateAsync(SubdivisionCategory subdivisionCategory, CancellationToken ct = default);
        Task RemoveAsync(SubdivisionCategory subdivisionCategory, CancellationToken ct = default);
        Task<IReadOnlyList<StateOrRegion>> GetStatesOrRegionsByCategoryAsync(int subdivisionCategoryId, CancellationToken ct = default);
        Task<SubdivisionCategory?> GetByDescriptionAsync(string description, CancellationToken ct = default);
        Task<bool> ExistsByDescriptionAsync(string description, CancellationToken ct = default);
        Task<IReadOnlyList<SubdivisionCategory>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}