using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
public class MembershipPeriodConfiguration : IEntityTypeConfiguration<MembershipPeriod>
    {
        public void Configure(EntityTypeBuilder<MembershipPeriod> builder)
        {
            builder.ToTable("membershipperiods");

            builder.HasKey(mp => mp.Id);

            builder.Property(mp => mp.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(mp => mp.MembershipId)
                .HasColumnName("membership_id")
                .IsRequired();

            builder.Property(mp => mp.PeriodId)
                .HasColumnName("period_id")
                .IsRequired();

            builder.Property(mp => mp.Name)
                .HasColumnName("name")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(mp => mp.Description)
                .HasColumnName("description")
                .IsRequired();

            builder.Property(mp => mp.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(mp => mp.AudienceBenefId)
                .HasColumnName("audiencebenef_id")
                .IsRequired();

            builder.Property(mp => mp.BenefaudId)
                .HasColumnName("beneaud_id")
                .IsRequired();

            builder.Property(mp => mp.CompanyId)
                .HasColumnName("companyId")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(mp => mp.Company)
                   .WithMany(c => c.MembershipPeriods)
                   .HasForeignKey(mp => mp.CompanyId);

            builder.HasOne(mp => mp.Membership)
                   .WithMany(m => m.MembershipPeriods)
                   .HasForeignKey(mp => mp.MembershipId);

            builder.HasOne(mp => mp.Period)
                   .WithMany(p => p.MembershipPeriods)
                   .HasForeignKey(mp => mp.PeriodId);

            builder.HasOne(mp => mp.AudienceBenefit)
                   .WithMany(ab => ab.MembershipPeriods)
                   .HasForeignKey(mp => new { mp.AudienceBenefId, mp.BenefaudId });
        }
    }
}