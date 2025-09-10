using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        // 🔗 Relación: un tipo tiene muchos productos
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}