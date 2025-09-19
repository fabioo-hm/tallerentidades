using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface ICompanyProductRepository
    {
        Task<CompanyProduct?> GetByIdAsync(string companyId, int productId, CancellationToken ct = default);
        Task<IReadOnlyList<CompanyProduct>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(CompanyProduct companyProduct, CancellationToken ct = default);
        Task UpdateAsync(CompanyProduct companyProduct, CancellationToken ct = default);
        Task RemoveAsync(CompanyProduct companyProduct, CancellationToken ct = default);
        Task<IReadOnlyList<CompanyProduct>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);
    }
}