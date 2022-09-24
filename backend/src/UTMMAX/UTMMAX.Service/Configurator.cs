using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Service.RepositoriesServices;

namespace UTMMAX.Service;

public static class Configurator
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}