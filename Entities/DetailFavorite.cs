using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class DetailFavorite
    {
        public int Id { get; set; }

        // 🔗 Relaciones
        public int FavoriteId { get; set; }
        public Favorite Favorite { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}