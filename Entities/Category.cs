using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Description { get; set; }

       public ICollection<Company> Companies { get; set; } = new List<Company>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}