using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.ToTable("memberships");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                    .HasColumnName("id")
                    .IsRequired();

            builder.Property(m => m.Name)
                    .HasColumnName("name")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(m => m.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .IsRequired();

            builder.HasIndex(m => m.Name).IsUnique();

            builder.HasMany(m => m.MembershipPeriods)
                   .WithOne(mp => mp.Membership)
                   .HasForeignKey(mp => mp.MembershipId);
        }
    }
}