using HeroesAPI.Models;
using HeroesAPI.Repositories;
using MongoDB.Driver;

namespace HeroesAPI.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        });
    }

    public static void ConfigureMongoDBSettings(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MongoDbSettings>(
            config.GetSection("MongoDBSettings")
        );

        services.AddSingleton<IMongoDatabase>(options =>
        {
            var settings = config.GetSection("MongoDBSettings").Get<MongoDbSettings>();
            var client = new MongoClient(settings.ConnectionString);
            return client.GetDatabase(settings.DatabaseName);
        });
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IHeroisRepository, HeroisRepository>();
    }
    
}
