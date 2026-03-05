using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Infrastructure.EntitiesConfiguration;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Quantity)
            .IsRequired();

        builder.Property(p => p.UnitPrice)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.HasOne<Item>()
            .WithMany()
            .HasForeignKey(i => i.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}