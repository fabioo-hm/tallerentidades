using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class SubdivisionCategory
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public ICollection<StateOrRegion> StateOrRegions { get; set; } = new List<StateOrRegion>();
    }
}