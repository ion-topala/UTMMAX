using System.ComponentModel;

namespace UTMMAX.Kinopoisk.Enums;

public enum MovieType
{
    [Description("movie")]           Movie          = 1,
    [Description("tv-series")]       TvSeries       = 2,
    [Description("cartoon")]         Cartoons       = 3,
    [Description("anime")]           Anime          = 4,
    [Description("animated-series")] AnimatedSeries = 5,
}