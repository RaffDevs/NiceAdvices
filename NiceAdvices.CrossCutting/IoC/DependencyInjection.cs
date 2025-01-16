using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NiceAdvices.Core.Repositories;
using NiceAdvices.Infrastructure.Persistence.Context;
using NiceAdvices.Infrastructure.Persistence.Repositories;

namespace NiceAdvices.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAdviceRepository, AdviceRepository>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<NiceAdvicesDatabaseContext>(options =>
        {
            options.UseSqlite("Data Source=advices.db");
        });
        
        return services;
    }

    public static IServiceCollection AddAdviceHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("Advices", client =>
        {
            client.BaseAddress = new Uri(configuration["Api:Advice"]);
        });
        return services;
    }
    
    public static IServiceCollection AddTranslatorHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient("Translator", client =>
        {
            client.BaseAddress = new Uri(configuration["Api:Translator"]);
        });

        return services;
    }
}