using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Framework.Managers;

namespace UTMMAX.Framework;

public static class Configurator
{
    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<UserManager>();
    }
}