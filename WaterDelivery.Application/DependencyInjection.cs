using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WaterDelivery.Application.Interfaces;
using WaterDelivery.Application.Services;

namespace WaterDelivery.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IEstablishmentService, EstablishmentService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}