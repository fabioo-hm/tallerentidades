using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.TypeId)
                .HasColumnName("type_id")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(c => c.CategoryId)
                .HasColumnName("category_id")
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
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasMaxLength(80)
                .IsRequired();

            builder.HasIndex(c => c.Cellphone).IsUnique();
            builder.HasIndex(c => c.Email).IsUnique();

            builder.HasOne(c => c.TypeIdentification)
                   .WithMany(t => t.Companies)
                   .HasForeignKey(c => c.TypeId);

            builder.HasOne(c => c.Category)
                   .WithMany(cat => cat.Companies)
                   .HasForeignKey(c => c.CategoryId);

            builder.HasOne(c => c.City)
                   .WithMany(ci => ci.Companies)
                   .HasForeignKey(c => c.CityId);

            builder.HasOne(c => c.Audience)
                   .WithMany(a => a.Companies)
                   .HasForeignKey(c => c.AudienceId);
        }
    }
}