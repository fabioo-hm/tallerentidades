using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class MembershipPeriodBenefitConfiguration : IEntityTypeConfiguration<MembershipPeriodBenefit>
    {
        public void Configure(EntityTypeBuilder<MembershipPeriodBenefit> builder)
        {
            builder.ToTable("membershipbenefits");

            builder.HasKey(mb => mb.Id);

            builder.Property(mb => mb.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(mb => mb.MembershipPeriodId)
                   .HasColumnName("membershipperiodId")
                   .IsRequired();

            builder.Property(mb => mb.BenefitId)
                   .HasColumnName("benefitId")
                   .IsRequired();

            // Relación con MembershipPeriods
            builder.HasOne(mpb => mpb.MembershipPeriod)
               .WithMany(mp => mp.MembershipPeriodBenefits) // 👈 apunta a la otra colección
               .HasForeignKey(mpb => mpb.MembershipPeriodId);

            // Relación con Benefits
            builder.HasOne(mb => mb.Benefit)
                   .WithMany(b => b.MembershipPeriodBenefits)
                   .HasForeignKey(mb => mb.BenefitId);
        }
    }
}