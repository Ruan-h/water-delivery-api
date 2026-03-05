using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Domain.Interfaces;
using WaterDelivery.Infrastructure.Authentication;
using WaterDelivery.Infrastructure.Context;
using WaterDelivery.Infrastructure.Repositories;

namespace WaterDelivery.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}