using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
 public class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.ToTable("benefits");

            // Clave primaria
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(b => b.Description)
                .HasColumnName("description")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(b => b.Detail)
                .HasColumnName("detail")
                .IsRequired();

            builder.Property(b => b.AudienceId)
                .HasColumnName("audience_id")
                .IsRequired();

            // Relaciones muchos a muchos (AudienceBenefits, MembershipBenefits)
            builder.HasMany(b => b.AudienceBenefits)
                .WithOne(ab => ab.Benefit)
                .HasForeignKey(ab => ab.BenefitId);

            builder.HasMany(b => b.MembershipPeriodBenefits)
                .WithOne(mpb => mpb.Benefit)
                .HasForeignKey(mpb => mpb.BenefitId);
        }
    }
}