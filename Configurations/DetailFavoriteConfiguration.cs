using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TareaEntidades.Entities;

namespace TareaEntidades.Configurations
{
    public class DetailFavoriteConfiguration : IEntityTypeConfiguration<DetailFavorite>
    {
        public void Configure(EntityTypeBuilder<DetailFavorite> builder)
        {
            builder.ToTable("details_favorites");

            builder.HasKey(df => df.Id);

            builder.Property(df => df.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(df => df.FavoriteId)
                   .HasColumnName("favorite_id")
                   .IsRequired();

            builder.Property(df => df.ProductId)
                   .HasColumnName("product_id")
                   .IsRequired();

            // Relación con Favorites
            builder.HasOne(df => df.Favorite)
                   .WithMany(f => f.DetailsFavorites)
                   .HasForeignKey(df => df.FavoriteId);

            // Relación con Products
            builder.HasOne(df => df.Product)
                   .WithMany(p => p.DetailFavorites)
                   .HasForeignKey(df => df.ProductId);
        }
    }
}