using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class MembershipPeriod
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public int PeriodId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int AudienceBenefId { get; set; }
        public int BenefaudId { get; set; }
        public string? CompanyId { get; set; }

        public Company? Company { get; set; }
        public Membership? Membership { get; set; }
        public Period? Period { get; set; }
        public AudienceBenefit AudienceBenefit { get; set; } = null!;

        public ICollection<MembershipBenefit> MembershipBenefits { get; set; } = new List<MembershipBenefit>();
        public ICollection<MembershipPeriodBenefit> MembershipPeriodBenefits { get; set; } = new List<MembershipPeriodBenefit>();

    }
}