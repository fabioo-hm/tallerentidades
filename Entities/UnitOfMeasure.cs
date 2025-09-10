using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;

        // 🔗 Relación con companyproducts
        public ICollection<CompanyProduct> CompanyProducts { get; set; } = new List<CompanyProduct>();
    }
}