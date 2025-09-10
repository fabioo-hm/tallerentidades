using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("countries");

            builder.HasKey(c => c.IsoCode);

            builder.Property(c => c.IsoCode)
                .HasColumnName("isocode")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.AlfaIsoTwo)
                .HasColumnName("alfaisotwo")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.AlfaIsoThree)
                .HasColumnName("alfaisothree")
                .HasMaxLength(4)
                .IsRequired();

            builder.HasIndex(c => c.Name).IsUnique();
            builder.HasIndex(c => c.AlfaIsoTwo).IsUnique();
            builder.HasIndex(c => c.AlfaIsoThree).IsUnique();

            builder.HasMany(c => c.StateOrRegions)
                   .WithOne(s => s.Country)
                   .HasForeignKey(s => s.CountryIsoCode);
        }
    }
}