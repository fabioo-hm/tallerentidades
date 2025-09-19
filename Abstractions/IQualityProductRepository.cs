using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IQualityProductRepository
    {
        Task<QualityProduct?> GetByIdAsync(int productId, int customerId, int pollId, CancellationToken ct = default);
        Task<IReadOnlyList<QualityProduct>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(QualityProduct qualityProduct, CancellationToken ct = default);
        Task UpdateAsync(QualityProduct qualityProduct, CancellationToken ct = default);
        Task RemoveAsync(QualityProduct qualityProduct, CancellationToken ct = default);
        Task<IReadOnlyList<QualityProduct>> GetByProductIdAsync(int productId, CancellationToken ct = default);
        Task<IReadOnlyList<QualityProduct>> GetByCustomerIdAsync(int customerId, CancellationToken ct = default);
        Task<IReadOnlyList<QualityProduct>> GetByPollIdAsync(int pollId, CancellationToken ct = default);
        Task<IReadOnlyList<QualityProduct>> GetByCompanyIdAsync(string companyId, CancellationToken ct = default);
        Task<double> GetAverageRatingByProductAsync(int productId, CancellationToken ct = default);
        Task<double> GetAverageRatingByCompanyAsync(string companyId, CancellationToken ct = default);
        Task<IReadOnlyList<QualityProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}