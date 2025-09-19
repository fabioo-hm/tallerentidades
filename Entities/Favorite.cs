using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Favorite
    {
        public int Id { get; set; }

        // 🔗 Relaciones
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public string? CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        // Relación con detalles de favoritos
        public ICollection<DetailFavorite> DetailsFavorites { get; set; } = new List<DetailFavorite>();
    }
}