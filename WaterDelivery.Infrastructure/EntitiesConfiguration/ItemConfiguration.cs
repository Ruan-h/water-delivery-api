using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Infrastructure.EntitiesConfiguration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.Price)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(p => p.Stock)
            .IsRequired();

        builder.Property(p => p.ImageUrl)
            .HasMaxLength(250);

        builder.HasData(
            new { Id = 1, Name = "Água Mineral 20L", Description = "Galão retornável de 20 litros", Price = 15.00m, Stock = 100, ImageUrl = "" },
            new { Id = 2, Name = "Gás de Cozinha 13kg", Description = "Botijão P13", Price = 105.00m, Stock = 50, ImageUrl = "" }
        );
    }
}