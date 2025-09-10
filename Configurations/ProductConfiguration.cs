using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.Name)
                   .HasColumnName("name")
                   .HasMaxLength(60)
                   .IsRequired();

            builder.HasIndex(p => p.Name)
                   .IsUnique();

            builder.Property(p => p.Detail)
                   .HasColumnName("detail");

            builder.Property(p => p.Price)
                   .HasColumnName("price")
                   .IsRequired();

            builder.Property(p => p.TypeProductId)
                   .HasColumnName("typeproductId")
                   .IsRequired();

            builder.Property(p => p.Image)
                   .HasColumnName("image")
                   .HasMaxLength(80);

            // Relaciones
            builder.HasOne(p => p.TypeProduct)
                   .WithMany(tp => tp.Products)
                   .HasForeignKey(p => p.TypeProductId);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey("category_id") // ⚠️ Confirmar si el modelo tiene esta FK
                   .IsRequired(false);
        }
    }
}