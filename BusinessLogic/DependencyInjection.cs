using BusinessLogic.Repositories;
using BusinessLogic.RespositoryContracts;
using BusinessLogic.Services;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BusinessLogic;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services , 
        IConfiguration configuration)
    {
        services.AddScoped<IOrderService, OrderService>();

        services.AddScoped<IOrdersRepository, OrderRepository>();


        // Register Mapster mapping profiles
        services.AddMapster();

        return services;
    }
}
