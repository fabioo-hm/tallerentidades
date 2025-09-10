using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class TypeIdentificationConfiguration : IEntityTypeConfiguration<TypeIdentification>
    {
        public void Configure(EntityTypeBuilder<TypeIdentification> builder)
        {
            builder.ToTable("typesidentifications");

            builder.HasKey(ti => ti.Id);

            builder.Property(ti => ti.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(ti => ti.Description)
                   .HasColumnName("description")
                   .HasMaxLength(60)
                   .IsRequired();

            builder.Property(ti => ti.Sufix)
                   .HasColumnName("sufix")
                   .HasMaxLength(5)
                   .IsRequired();
            
            builder.HasIndex(ti => ti.Description).IsUnique();
            builder.HasIndex(ti => ti.Sufix).IsUnique();

            builder.HasMany(ti => ti.Companies)
                   .WithOne(c => c.TypeIdentification)
                   .HasForeignKey(c => c.TypeId);
        }
    }
}