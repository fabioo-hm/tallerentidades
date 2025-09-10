using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable("rates");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(r => r.CustomerId)
                   .HasColumnName("customer_id")
                   .IsRequired();

            builder.Property(r => r.CompanyId)
                   .HasColumnName("company_id")
                   .IsRequired();

            builder.Property(r => r.PollId)
                   .HasColumnName("poll_id")
                   .IsRequired();

            builder.Property(r => r.DateRating)
                   .HasColumnName("daterating")
                   .IsRequired();

            builder.Property(r => r.RatingValue)
                   .HasColumnName("rating")
                   .IsRequired();

            // Relación con Customers
            builder.HasOne(r => r.Customer)
                   .WithMany(c => c.Rates)
                   .HasForeignKey(r => r.CustomerId);

            // Relación con Companies
            builder.HasOne(r => r.Company)
                   .WithMany(c => c.Rates)
                   .HasForeignKey(r => r.CompanyId);

            // Relación con Polls
            builder.HasOne(r => r.Poll)
                   .WithMany(p => p.Rates)
                   .HasForeignKey(r => r.PollId);

            // 🔑 Restricción única: un cliente no puede calificar la misma empresa en la misma encuesta más de una vez
            builder.HasIndex(r => new { r.CustomerId, r.CompanyId, r.PollId })
                   .IsUnique();
        }
    }
}