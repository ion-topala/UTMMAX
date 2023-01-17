namespace UTMMAX.Movie.Models;

public class Rating : BaseMovieModel
{
    public double Kp                 { get; set; }
    public double Imdb               { get; set; }
    public double FilmCritics        { get; set; }
    public double RussianFilmCritics { get; set; }
    public double Await              { get; set; }
}