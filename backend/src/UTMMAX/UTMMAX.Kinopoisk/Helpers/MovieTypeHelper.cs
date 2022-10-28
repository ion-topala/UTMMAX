using UTMMAX.Kinopoisk.Enums;

namespace UTMMAX.Kinopoisk.Helpers;

public static class MovieTypeHelper
{
    public static MovieType GetTypeByString(string? value)
    {
        return value switch
        {
            "tv-series"       => MovieType.TvSeries,
            "cartoon"         => MovieType.Cartoons,
            "movie"           => MovieType.Movie,
            "anime"           => MovieType.Anime,
            "animated-series" => MovieType.AnimatedSeries,
            _                 => 0
        };
    }
}