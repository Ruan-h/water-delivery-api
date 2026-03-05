using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterDelivery.Domain.Entities;

namespace WaterDelivery.Infrastructure.EntitiesConfiguration;

public class EstablishmentConfiguration : IEntityTypeConfiguration<Establishment>
{
    public void Configure(EntityTypeBuilder<Establishment> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.IsOpen)
            .IsRequired();

        builder.HasData(
            new { Id = 1, Name = "Water Delivery", IsOpen = true }
        );
    }
}