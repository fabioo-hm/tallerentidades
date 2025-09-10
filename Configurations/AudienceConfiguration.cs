using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class AudienceConfiguration : IEntityTypeConfiguration<Audience>
    {
        public void Configure(EntityTypeBuilder<Audience> builder)
        {
            builder.ToTable("audiences");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(a => a.Description)
                   .HasColumnName("description")
                   .HasMaxLength(60)
                   .IsRequired();

            // 🔗 Relaciones
            builder.HasMany(a => a.Companies)
                   .WithOne(c => c.Audience)
                   .HasForeignKey(c => c.AudienceId);

            builder.HasMany(a => a.AudienceBenefits)
                   .WithOne(ab => ab.Audience)
                   .HasForeignKey(ab => ab.AudienceId);

            builder.HasMany(a => a.Customers)
                   .WithOne(cu => cu.Audience)
                   .HasForeignKey(cu => cu.AudienceId);
        }
    }
}