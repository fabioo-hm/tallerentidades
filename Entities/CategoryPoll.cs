using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class CategoryPoll
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // 🔗 Relación: una categoría puede tener muchas encuestas
        public ICollection<Poll> Polls { get; set; } = new List<Poll>();
    }
}