using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }

        // 🔗 Relaciones
        public int CategoryPollId { get; set; }
        public CategoryPoll CategoryPoll { get; set; } = null!;

        // Colecciones relacionadas
        public ICollection<Rate> Rates { get; set; } = new List<Rate>();
        public ICollection<QualityProduct> QualityProducts { get; set; } = new List<QualityProduct>();

        // Relación recursiva (si aplica)
        public ICollection<Poll> SubPolls { get; set; } = new List<Poll>();
    }
}