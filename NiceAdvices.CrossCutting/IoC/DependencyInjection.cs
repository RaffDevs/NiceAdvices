using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NiceAdvices.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddAdviceHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
    
    public static IServiceCollection AddTranslatorHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}