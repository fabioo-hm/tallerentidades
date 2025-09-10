using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class CityOrMunicipality
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? StateOrRegionCode { get; set; }  // FK
        public StateOrRegion? StateOrRegion { get; set; }
        public ICollection<Company> Companies { get; set; } = new List<Company>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}