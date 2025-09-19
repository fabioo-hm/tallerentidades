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

        public Audience? Audience { get; set; }
        public Benefit? Benefit { get; set; }

        public ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new List<MembershipPeriod>();
        public ICollection<MembershipBenefit> MembershipBenefits { get; set; } = new List<MembershipBenefit>();
    }
}