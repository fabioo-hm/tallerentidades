using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class MembershipBenefitConfiguration : IEntityTypeConfiguration<MembershipBenefit>
    {
        public void Configure(EntityTypeBuilder<MembershipBenefit> builder)
        {
            builder.ToTable("membershipbenefits");

            // Clave primaria compuesta
            builder.HasKey(mb => new { mb.MembershipId, mb.PeriodId, mb.AudienceId, mb.BenefitId });

            builder.Property(mb => mb.MembershipId)
                   .HasColumnName("membership_id")
                   .IsRequired();

            builder.Property(mb => mb.PeriodId)
                   .HasColumnName("period_id")
                   .IsRequired();

            builder.Property(mb => mb.AudienceId)
                   .HasColumnName("audience_id")
                   .IsRequired();

            builder.Property(mb => mb.BenefitId)
                   .HasColumnName("benefit_id")
                   .IsRequired();

            builder.HasOne(mb => mb.MembershipPeriod)
                    .WithMany(mp => mp.MembershipBenefits) // 👈 ya coincide
                    .HasForeignKey(mb => new { mb.MembershipId, mb.PeriodId });


            // Relación con AudienceBenefits
            builder.HasOne(mb => mb.AudienceBenefit)
                   .WithMany(ab => ab.MembershipBenefits)
                   .HasForeignKey(mb => new { mb.AudienceId, mb.BenefitId });
        }
    }
}