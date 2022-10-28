using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Framework.Mappers.MovieMappers;
using UTMMAX.Framework.Mappers.UserMappers;

namespace UTMMAX.Framework.Mappers;

public static class Configurator
{
    public static void AddMappers(this IServiceCollection services)
    {
        services.AddScoped<IUserMapper, UserMapper>();
        services.AddScoped<IMovieMapper, MovieMapper>();
    }
}