using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TareaEntidades.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TareaEntidades.Configurations
{
    public class CitiesOrMunicipalitiesConfiguration : IEntityTypeConfiguration<CityOrMunicipality>
    {
        public void Configure(EntityTypeBuilder<CityOrMunicipality> builder)
        {
            builder.ToTable("citiesormunicipalities");

            builder.HasKey(c => c.Code);

            builder.Property(c => c.Code)
                   .HasColumnName("code")
                   .HasMaxLength(6)
                   .IsRequired();

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasMaxLength(60)
                   .IsRequired();

            builder.Property(c => c.StateOrRegionCode)
                   .HasColumnName("statereg_id")
                   .HasMaxLength(6)
                   .IsRequired();

            builder.HasIndex(c => new { c.Name, c.Code}).IsUnique();

            builder.HasOne(c => c.StateOrRegion)
                   .WithMany(s => s.CitiesOrMunicipalities)
                   .HasForeignKey(c => c.StateOrRegionCode);
        }
        
    }
}