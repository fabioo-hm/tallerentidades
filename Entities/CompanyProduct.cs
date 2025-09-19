using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class CompanyProduct
    {
        public string? CompanyId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int UnitMeasureId { get; set; }

        public Company Company { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public UnitOfMeasure UnitOfMeasure { get; set; } = null!;
    }
}