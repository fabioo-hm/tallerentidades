using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
        {
            builder.ToTable("unitofmeasure");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(u => u.Description)
                   .HasColumnName("description")
                   .HasMaxLength(60)
                   .IsRequired();

            // 🔑 Restricción de unicidad
            builder.HasIndex(u => u.Description)
                   .IsUnique();

            // Relación con companyproducts
            builder.HasMany(u => u.CompanyProducts)
                   .WithOne(cp => cp.UnitOfMeasure)
                   .HasForeignKey(cp => cp.UnitMeasureId);
        }
    }
}