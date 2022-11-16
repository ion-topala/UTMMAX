using Microsoft.Extensions.DependencyInjection;

namespace UTMMAX.Framework.Managers;

public static class Configurator
{
    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<AuthenticationManager>();
        services.AddScoped<IdentityManager>();
        services.AddScoped<MovieManager>();
    }
}