using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Service;

namespace UTMMAX.Files;

public static class Configurator
{
    public static void AddFileService(this IServiceCollection collection)
    {
        collection.AddScoped<IFileService, FileService>();
    }
}