using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Infrastructure.EntitiesConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.DeliveryAddress)
            .HasMaxLength(255)
            .IsRequired();


        builder.Property(p => p.TotalAmount)
            .HasPrecision(10, 2)
            .IsRequired();


        builder.Property(p => p.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.HasOne<Client>()
            .WithMany()
            .HasForeignKey(o => o.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(i => i.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Metadata
            .FindNavigation(nameof(Order.Items))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}