using UTMMAX.Kinopoisk.Enums;

namespace UTMMAX.Framework.Models.Movie;

public class MovieResultModel
{
    public int?        Id               { get; set; }
    public MovieType   Type             { get; set; }
    public string?     Description      { get; set; }
    public int?        Year             { get; set; }
    public string?     AlternativeName  { get; set; }
    public string?     EnName           { get; set; }
    public int?        MovieLength      { get; set; }
    public string?     ShortDescription { get; set; }
    public string      LogoUrl          { get; set; }
    public string      PosterUrl        { get; set; }
    public string      PosterPreviewUrl { get; set; }
    public VotesModel  Votes            { get; set; }
    public RatingModel Rating           { get; set; }
}