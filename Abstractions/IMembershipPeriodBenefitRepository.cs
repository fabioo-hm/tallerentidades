using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaEntidades.Entities;

namespace TareaEntidades.Abstractions
{
    public interface IMembershipPeriodBenefitRepository
    {
        Task<MembershipPeriodBenefit?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipPeriodBenefit>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(MembershipPeriodBenefit membershipPeriodBenefit, CancellationToken ct = default);
        Task UpdateAsync(MembershipPeriodBenefit membershipPeriodBenefit, CancellationToken ct = default);
        Task RemoveAsync(MembershipPeriodBenefit membershipPeriodBenefit, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipPeriodBenefit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
        Task<int> CountAsync(string? search = null, CancellationToken ct = default);

        // 🔗 Métodos personalizados
        Task<IReadOnlyList<MembershipPeriodBenefit>> GetByMembershipPeriodIdAsync(int membershipPeriodId, CancellationToken ct = default);
        Task<IReadOnlyList<MembershipPeriodBenefit>> GetByBenefitIdAsync(int benefitId, CancellationToken ct = default);
    }
}