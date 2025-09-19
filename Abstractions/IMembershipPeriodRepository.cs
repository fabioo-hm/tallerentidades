using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IMembershipPeriodRepository
    {
        Task<MembershipPeriod?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipPeriod>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(MembershipPeriod membershipPeriod, CancellationToken ct = default);
        Task UpdateAsync(MembershipPeriod membershipPeriod, CancellationToken ct = default);
        Task RemoveAsync(MembershipPeriod membershipPeriod, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipPeriod>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);

        // 🔗 Métodos personalizados
        Task<IReadOnlyList<MembershipPeriod>> GetByMembershipIdAsync(int membershipId, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipPeriod>> GetByPeriodIdAsync(int periodId, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipPeriod>> GetByCompanyIdAsync(string companyId, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipPeriod>> GetByAudienceBenefitIdAsync(int audienceBenefitId, CancellationToken ct = default);
    }
}