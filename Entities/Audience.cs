using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Audience
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public ICollection<Company> Companies { get; set; } = new List<Company>();
        public ICollection<AudienceBenefit> AudienceBenefits { get; set; } = new List<AudienceBenefit>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}