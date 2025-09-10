using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
public class QualityProductConfiguration : IEntityTypeConfiguration<QualityProduct>
    {
        public void Configure(EntityTypeBuilder<QualityProduct> builder)
        {
            builder.ToTable("quality_products");

            // PK compuesta
            builder.HasKey(qp => new { qp.ProductId, qp.CustomerId, qp.PollId, qp.CompanyId });

            builder.Property(qp => qp.ProductId)
                   .HasColumnName("product_id")
                   .IsRequired();

            builder.Property(qp => qp.CustomerId)
                   .HasColumnName("customer_id")
                   .IsRequired();

            builder.Property(qp => qp.PollId)
                   .HasColumnName("poll_id")
                   .IsRequired();

            builder.Property(qp => qp.CompanyId)
                   .HasColumnName("company_id")
                   .IsRequired();

            builder.Property(qp => qp.DateRating)
                   .HasColumnName("daterating")
                   .IsRequired();

            builder.Property(qp => qp.Rating)
                   .HasColumnName("rating")
                   .IsRequired();

            // Relaciones
            builder.HasOne(qp => qp.Product)
                   .WithMany(p => p.QualityProducts)
                   .HasForeignKey(qp => qp.ProductId);

            builder.HasOne(qp => qp.Customer)
                   .WithMany(c => c.QualityProducts)
                   .HasForeignKey(qp => qp.CustomerId);

            builder.HasOne(qp => qp.Poll)
                   .WithMany(p => p.QualityProducts)
                   .HasForeignKey(qp => qp.PollId);

            builder.HasOne(qp => qp.Company)
                   .WithMany(c => c.QualityProducts)
                   .HasForeignKey(qp => qp.CompanyId);
        }
    }
}