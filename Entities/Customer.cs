using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CityId { get; set; } = null!;
        public int AudienceId { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        // 🔗 Relaciones
        public CityOrMunicipality City { get; set; } = null!;
        public Audience Audience { get; set; } = null!;

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Rate> Rates { get; set; } = new List<Rate>();
        public ICollection<QualityProduct> QualityProducts { get; set; } = new List<QualityProduct>();
    }
}