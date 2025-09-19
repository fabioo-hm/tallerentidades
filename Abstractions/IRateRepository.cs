using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IRateRepository
    {
        Task<Rate?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<Rate>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Rate rate, CancellationToken ct = default);
        Task UpdateAsync(Rate rate, CancellationToken ct = default);
        Task RemoveAsync(Rate rate, CancellationToken ct = default);

        // 🔎 Personalizadas
        Task<IReadOnlyList<Rate>> GetByCustomerAsync(int customerId, CancellationToken ct = default);
        Task<IReadOnlyList<Rate>> GetByCompanyAsync(string companyId, CancellationToken ct = default);
        Task<IReadOnlyList<Rate>> GetByPollAsync(int pollId, CancellationToken ct = default);

        Task<double> GetAverageRatingByPollAsync(int pollId, CancellationToken ct = default);
        Task<double> GetAverageRatingByCompanyAsync(string companyId, CancellationToken ct = default);

        Task<IReadOnlyList<Rate>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken ct = default);

        Task<IReadOnlyList<Rate>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}