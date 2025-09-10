using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id");

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(c => c.CityId)
                   .HasColumnName("city_id")
                   .HasMaxLength(6)
                   .IsRequired();

            builder.Property(c => c.AudienceId)
                   .HasColumnName("audience_id")
                   .IsRequired();

            builder.Property(c => c.Cellphone)
                   .HasColumnName("cellphone")
                   .HasMaxLength(20);

            builder.Property(c => c.Email)
                   .HasColumnName("email")
                   .HasMaxLength(100);

            builder.Property(c => c.Address)
                   .HasColumnName("address")
                   .HasMaxLength(120);

            // Relaciones
            builder.HasOne(c => c.City)
                   .WithMany(cm => cm.Customers)
                   .HasForeignKey(c => c.CityId);

            builder.HasOne(c => c.Audience)
                   .WithMany(a => a.Customers)
                   .HasForeignKey(c => c.AudienceId);
        }
    }
}