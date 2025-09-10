using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class TypeIdentification
    {
        public int Id { get; set; }
        public string? Description { get; set; } 
        public string? Sufix { get; set; }
        public ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}