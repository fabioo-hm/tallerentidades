using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class MembershipBenefit
    {
        public int MembershipId { get; set; }
        public int PeriodId { get; set; }
        public int AudienceId { get; set; }
        public int BenefitId { get; set; }

        // 🔗 Relaciones
        public MembershipPeriod MembershipPeriod { get; set; } = null!;
        public AudienceBenefit AudienceBenefit { get; set; } = null!;
    }
}