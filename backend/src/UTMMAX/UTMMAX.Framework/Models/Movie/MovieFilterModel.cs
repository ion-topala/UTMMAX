using UTMMAX.Kinopoisk.Enums;

namespace UTMMAX.Framework.Models.Movie;

public class MovieFilterModel
{
    public MovieType Type  { get; set; }
    public int       Limit { get; set; } = 10;
}