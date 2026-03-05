using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaterDelivery.Domain.Entities;
using WaterDelivery.Domain.Enums;

namespace WaterDelivery.Infrastructure.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne(u => u.Client)
            .WithOne(c => c.User)
            .HasForeignKey<Client>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new
        {
            Id = 1,
            Email = "admin@water.com",
            PasswordHash = "$2a$10$vI8aWBnW3fID.ZQ4/zo1G.q1lRps.9cGLcZEiGDMVr5yUP1KUOYTa",
            Role = UserRole.Admin
        });
    }
}