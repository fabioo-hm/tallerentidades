using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
        public class Company
    {
        public string? Id { get; set; } 
        public int TypeId { get; set; }     
        public string? Name { get; set; }
        public int CategoryId { get; set; } 
        public string? CityId { get; set; } // FK a citiesormunicipalitie
        public int AudienceId { get; set; }       // FK a audiences
        public string? Cellphone { get; set; }
        public string? Email { get; set; }

        public TypeIdentification? TypeIdentification { get; set; }
        public Category? Category { get; set; }
        public CityOrMunicipality? City { get; set; }
        public Audience? Audience { get; set; }

        public ICollection<CompanyProduct> CompanyProducts { get; set; } = new List<CompanyProduct>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Rate> Rates { get; set; } = new List<Rate>();
        public ICollection<QualityProduct> QualityProducts { get; set; } = new List<QualityProduct>();
        public ICollection<MembershipPeriod> MembershipPeriods { get; set; } = new List<MembershipPeriod>();
    }

}