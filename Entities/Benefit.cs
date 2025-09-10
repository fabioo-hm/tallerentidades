using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Benefit
    {
        public int Id { get; set; }  // PK
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public int AudienceId { get; set; }  // FK

        public Audience? Audience { get; set; }
        public ICollection<AudienceBenefit> AudienceBenefits { get; set; } = new List<AudienceBenefit>();
        public ICollection<MembershipPeriodBenefit> MembershipPeriodBenefits { get; set; } = new List<MembershipPeriodBenefit>();
    }
}