using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Framework.Managers;
using UTMMAX.Framework.Mappers;
using UTMMAX.Framework.Validators;

namespace UTMMAX.Framework;

public static class Configurator
{
    public static void AddFramework(this IServiceCollection services)
    {
        services.AddValidators();
        services.AddManagers();
        services.AddMappers();
    }
}