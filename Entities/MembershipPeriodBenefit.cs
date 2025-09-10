using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class MembershipPeriodBenefit
    {
        public int Id { get; set; }

        public int MembershipPeriodId { get; set; }
        public MembershipPeriod MembershipPeriod { get; set; } = null!;

        public int BenefitId { get; set; }
        public Benefit Benefit { get; set; } = null!;
    }
}