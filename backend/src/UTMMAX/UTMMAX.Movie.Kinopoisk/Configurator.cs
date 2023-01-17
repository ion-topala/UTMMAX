using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Service;

namespace UTMMAX.Kinopoisk;

public static class Configurator
{
    public static void AddKinopoiskService(this IServiceCollection serviceCollection, KinopoiskConfig kinopoiskConfig)
    {
        serviceCollection.AddScoped<IKinopoiskService>(_ =>
        {
            var httpClient = new HttpClient();

            return new KinopoiskService(kinopoiskConfig, httpClient);
        });
    }
}