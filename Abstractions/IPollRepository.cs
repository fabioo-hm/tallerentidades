using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IPollRepository
    {
        Task<Poll?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<Poll>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Poll poll, CancellationToken ct = default);
        Task UpdateAsync(Poll poll, CancellationToken ct = default);
        Task RemoveAsync(Poll poll, CancellationToken ct = default);

        // 🔎 Personalizadas
        Task<IReadOnlyList<Poll>> GetByCategoryAsync(int categoryPollId, CancellationToken ct = default);
        Task<IReadOnlyList<Poll>> GetActivePollsAsync(CancellationToken ct = default);
        Task<IReadOnlyList<Poll>> GetInactivePollsAsync(CancellationToken ct = default);

        Task<IReadOnlyList<Poll>> GetByNameAsync(string name, CancellationToken ct = default);
        Task<IReadOnlyList<Poll>> GetByDescriptionAsync(string keyword, CancellationToken ct = default);

        Task<IReadOnlyList<Poll>> GetSubPollsAsync(int parentPollId, CancellationToken ct = default);

        Task<IReadOnlyList<Poll>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}