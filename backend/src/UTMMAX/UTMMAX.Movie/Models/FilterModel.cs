using UTMMAX.Kinopoisk.Enums;

namespace UTMMAX.Movie.Models;

public class FilterModel
{
    public string    SearchTerm { get; set; }
    public int       Limit      { get; set; } = 10;
    public MovieType Type       { get; set; } = MovieType.Movie;
}