using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("favorites");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(f => f.CustomerId)
                   .HasColumnName("customer_id")
                   .IsRequired();

            builder.Property(f => f.CompanyId)
                   .HasColumnName("company_id")
                   .IsRequired();

            // Relación con Customers
            builder.HasOne(f => f.Customer)
                   .WithMany(c => c.Favorites)
                   .HasForeignKey(f => f.CustomerId);

            // Relación con Companies
            builder.HasOne(f => f.Company)
                   .WithMany(c => c.Favorites)
                   .HasForeignKey(f => f.CompanyId);

            // Relación con DetailsFavorites
            builder.HasMany(f => f.DetailsFavorites)
                   .WithOne(df => df.Favorite)
                   .HasForeignKey(df => df.FavoriteId);
        }
    }
}