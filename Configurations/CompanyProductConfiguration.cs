using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class CompanyProductConfiguration : IEntityTypeConfiguration<CompanyProduct>
    {
        public void Configure(EntityTypeBuilder<CompanyProduct> builder)
        {
            builder.ToTable("companyproducts");

            // 🔑 Llave primaria compuesta
            builder.HasKey(cp => new { cp.CompanyId, cp.ProductId });

            builder.Property(cp => cp.CompanyId)
                   .HasColumnName("company_id")
                   .IsRequired();

            builder.Property(cp => cp.ProductId)
                   .HasColumnName("product_id")
                   .IsRequired();

            builder.Property(cp => cp.Price)
                   .HasColumnName("price")
                   .IsRequired();

            builder.Property(cp => cp.UnitMeasureId)
                   .HasColumnName("unitmeasure_id")
                   .IsRequired();

            // Relaciones
            builder.HasOne(cp => cp.Company)
                   .WithMany(c => c.CompanyProducts)
                   .HasForeignKey(cp => cp.CompanyId);

            builder.HasOne(cp => cp.Product)
                   .WithMany(p => p.CompanyProducts)
                   .HasForeignKey(cp => cp.ProductId);

            builder.HasOne(cp => cp.UnitOfMeasure)
                   .WithMany(u => u.CompanyProducts)
                   .HasForeignKey(cp => cp.UnitMeasureId);
        }
    }
}