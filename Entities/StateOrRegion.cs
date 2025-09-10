using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class StateOrRegion
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? CountryIsoCode { get; set; }
        public string? Code3166 { get; set; }
        public int SubdivisionCategoryId { get; set; }

        public Country? Country { get; set; }
        public SubdivisionCategory? SubdivisionCategory { get; set; }
        public ICollection<CityOrMunicipality> CitiesOrMunicipalities { get; set; } = new List<CityOrMunicipality>();
    }
}