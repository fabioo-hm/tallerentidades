using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IMembershipBenefitRepository
    {
        Task<MembershipBenefit?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipBenefit>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(MembershipBenefit membershipBenefit, CancellationToken ct = default);
        Task UpdateAsync(MembershipBenefit membershipBenefit, CancellationToken ct = default);
        Task RemoveAsync(MembershipBenefit membershipBenefit, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipBenefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);

        // 🔗 Métodos personalizados
        Task<IReadOnlyList<MembershipBenefit>> GetByMembershipPeriodIdAsync(int membershipPeriodId, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipBenefit>> GetByAudienceIdAsync(int audienceId, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipBenefit>> GetByBenefitIdAsync(int benefitId, CancellationToken ct = default);
    }
}