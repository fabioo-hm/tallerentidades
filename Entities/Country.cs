using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Country
    {
        public string? IsoCode { get; set; }
        public string? Name { get; set; }
        public string? AlfaIsoTwo { get; set; }
        public string? AlfaIsoThree { get; set; }
        public ICollection<StateOrRegion> StateOrRegions { get; set; } = new List<StateOrRegion>();
    }
}