using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class PollConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("polls");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(p => p.Name)
                   .HasColumnName("name")
                   .HasMaxLength(80)
                   .IsRequired();

            builder.HasIndex(p => p.Name)
                   .IsUnique();

            builder.Property(p => p.Description)
                   .HasColumnName("description")
                   .IsRequired();

            builder.Property(p => p.IsActive)
                   .HasColumnName("isactive")
                   .IsRequired();

            builder.Property(p => p.CategoryPollId)
                   .HasColumnName("categorypoll_id")
                   .IsRequired();

            // Relación con CategoryPoll
            builder.HasOne(p => p.CategoryPoll)
                   .WithMany(c => c.Polls)
                   .HasForeignKey(p => p.CategoryPollId);

            // Relación recursiva (si tu modelo la necesita explícitamente)
            builder.HasMany(p => p.SubPolls)
                   .WithOne()
                   .HasForeignKey("ParentPollId") // se tendría que agregar esta FK en BD
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}