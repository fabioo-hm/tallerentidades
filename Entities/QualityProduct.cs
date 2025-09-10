using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class QualityProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int PollId { get; set; }
        public Poll Poll { get; set; } = null!;

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public DateTime DateRating { get; set; }
        public double Rating { get; set; }
    }
}