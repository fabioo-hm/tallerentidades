using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class AudienceBenefit
    {
        public int AudienceId { get; set; }
        public int BenefitId { get; set; }

        public Audience Audience { get; set; } = null!;
        public Benefit Benefit { get; set; } = null!;

        public ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new List<MembershipPeriod>();
        public ICollection<MembershipBenefit> MembershipBenefits { get; set; } = new List<MembershipBenefit>();
    }
}