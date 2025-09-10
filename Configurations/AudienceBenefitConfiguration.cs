using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class AudienceBenefitConfiguration : IEntityTypeConfiguration<AudienceBenefit>
    {
        public void Configure(EntityTypeBuilder<AudienceBenefit> builder)
        {
            builder.ToTable("audiencebenefits");

            // Clave compuesta
            builder.HasKey(ab => new { ab.AudienceId, ab.BenefitId });

            builder.Property(ab => ab.AudienceId)
                   .HasColumnName("audience_id")
                   .IsRequired();

            builder.Property(ab => ab.BenefitId)
                   .HasColumnName("benefit_id")
                   .IsRequired();

            // Relación con Audience
            builder.HasOne(ab => ab.Audience)
                   .WithMany(a => a.AudienceBenefits)
                   .HasForeignKey(ab => ab.AudienceId);

            // Relación con Benefit
            builder.HasOne(ab => ab.Benefit)
                   .WithMany(b => b.AudienceBenefits)
                   .HasForeignKey(ab => ab.BenefitId);
                   
            // Relación con MembershipBenefits
                     builder.HasMany(ab => ab.MembershipBenefits)
                   .WithOne(mb => mb.AudienceBenefit)
                   .HasForeignKey(mb => new { mb.AudienceId, mb.BenefitId });
        }
    }
}