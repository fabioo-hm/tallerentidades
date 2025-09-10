using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class TypeProductConfiguration : IEntityTypeConfiguration<TypeProduct>
    {
        public void Configure(EntityTypeBuilder<TypeProduct> builder)
        {
            builder.ToTable("typesproducts");

            builder.HasKey(tp => tp.Id);

            builder.Property(tp => tp.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(tp => tp.Description)
                   .HasColumnName("description")
                   .HasMaxLength(80)
                   .IsRequired();

            builder.HasIndex(tp => tp.Description)
                   .IsUnique();

            // Relación: 1 tipo de producto -> muchos productos
            builder.HasMany(tp => tp.Products)
                   .WithOne(p => p.TypeProduct)
                   .HasForeignKey(p => p.TypeProductId);
        }
    }
}