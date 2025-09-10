using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Period
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new List<MembershipPeriod>();
    }
}