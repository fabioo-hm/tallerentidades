using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class MembershipBenefit
    {
        public int Id { get; set; }

        public int MembershipPeriodId { get; set; } 
        public MembershipPeriod MembershipPeriod { get; set; } = null!;

        public int AudienceId { get; set; }
        public int BenefitId { get; set; }

        public AudienceBenefit AudienceBenefit { get; set; } = null!;
    }
}