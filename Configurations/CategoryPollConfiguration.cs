using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class CategoryPollConfiguration : IEntityTypeConfiguration<CategoryPoll>
    {
        public void Configure(EntityTypeBuilder<CategoryPoll> builder)
        {
            builder.ToTable("categories_polls");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasMaxLength(80)
                   .IsRequired();

            builder.HasIndex(c => c.Name)
                   .IsUnique();

            // Relación: 1 categoría -> muchas encuestas
            builder.HasMany(c => c.Polls)
                   .WithOne(p => p.CategoryPoll)
                   .HasForeignKey(p => p.CategoryPollId);
        }
    }
}