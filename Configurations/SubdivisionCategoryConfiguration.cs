using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
     public class SubdivisionCategoryConfiguration : IEntityTypeConfiguration<SubdivisionCategory>
    {
        public void Configure(EntityTypeBuilder<SubdivisionCategory> builder)
        {
            builder.ToTable("subdivisioncategories");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(sc => sc.Description)
                .HasColumnName("description")
                .HasMaxLength(40)
                .IsRequired();

            builder.HasIndex(sc => sc.Description).IsUnique();

            builder.HasMany(sc => sc.StateOrRegions)
                   .WithOne(s => s.SubdivisionCategory)
                   .HasForeignKey(s => s.SubdivisionCategoryId);
        }
    }
}