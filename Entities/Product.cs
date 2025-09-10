using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TareaEntidades.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public double Price { get; set; }
        public int TypeProductId { get; set; }
        public int CategoryId { get; set; } 
        public string? Image { get; set; }

        public TypeProduct TypeProduct { get; set; } = null!;
        public Category Category { get; set; } = null!;

        public ICollection<CompanyProduct> CompanyProducts { get; set; } = new List<CompanyProduct>();
        public ICollection<DetailFavorite> DetailFavorites { get; set; } = new List<DetailFavorite>();
        public ICollection<QualityProduct> QualityProducts { get; set; } = new List<QualityProduct>();
    }
}