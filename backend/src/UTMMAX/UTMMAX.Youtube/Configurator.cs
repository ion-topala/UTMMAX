using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Service;

namespace UTMMAX.Youtube;

public static class Configurator
{
    public static void AddYoutubeServices(this IServiceCollection serviceCollection, YoutubeConfig config)
    {
        serviceCollection.AddHttpClient<IYoutubeService, YoutubeService>();
    }
}