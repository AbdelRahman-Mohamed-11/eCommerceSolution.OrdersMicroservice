using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionStringTemplate = configuration.GetConnectionString("MongoDB")!;

        string connectionString = connectionStringTemplate
            .Replace("$MONGO_HOST", Environment.GetEnvironmentVariable("MONGO_HOST") ?? "localhost")
            .Replace("$MONGO_PORT", Environment.GetEnvironmentVariable("MONGO_PORT") ?? "27017");

        services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

        services.AddScoped<IMongoDatabase>(provider =>
        {
            var client = provider.GetRequiredService<IMongoClient>();
            return client.GetDatabase("OrdersDatabase");
        });


        return services;
    }
}
