using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class StateOrRegionConfiguration : IEntityTypeConfiguration<StateOrRegion>
    {
        public void Configure(EntityTypeBuilder<StateOrRegion> builder)
        {
            builder.ToTable("stateorregions");

            builder.HasKey(s => s.Code);

            builder.Property(s => s.Code)
                .HasColumnName("code")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(s => s.CountryIsoCode)
                .HasColumnName("country_id")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(s => s.Code3166)
                .HasColumnName("code3166")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(s => s.SubdivisionCategoryId)
                .HasColumnName("subdivision_id")
                .IsRequired();

            builder.HasIndex(s => s.Name).IsUnique();

            builder.HasOne(s => s.Country)
                   .WithMany(c => c.StateOrRegions)
                   .HasForeignKey(s => s.CountryIsoCode);

            builder.HasOne(s => s.SubdivisionCategory)
                   .WithMany(sc => sc.StateOrRegions)
                   .HasForeignKey(s => s.SubdivisionCategoryId);

            builder.HasMany(s => s.CitiesOrMunicipalities)
                   .WithOne(c => c.StateOrRegion)
                   .HasForeignKey(c => c.StateOrRegionCode);
        }
    }
}