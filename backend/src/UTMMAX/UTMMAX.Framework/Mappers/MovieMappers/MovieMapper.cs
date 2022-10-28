using UTMMAX.Framework.Models.Movie;
using UTMMAX.Kinopoisk.Helpers;
using UTMMAX.Kinopoisk.Models;

namespace UTMMAX.Framework.Mappers.MovieMappers;

public class MovieMapper : IMovieMapper
{
    public MovieResultModel Map(MovieModel movieModel)
    {
        return new MovieResultModel
        {
            Id               = movieModel.Id,
            Type             = MovieTypeHelper.GetTypeByString(movieModel.Type),
            Description      = movieModel.Description,
            Year             = movieModel.Year,
            AlternativeName  = movieModel.AlternativeName,
            EnName           = movieModel.EnName,
            MovieLength      = movieModel.MovieLenght,
            ShortDescription = movieModel.ShortDescription,
            LogoUrl          = movieModel.Logo.Url,
            PosterUrl        = movieModel.Poster.Url,
            PosterPreviewUrl = movieModel.Poster.PreviewUrl,
            Votes = new VotesModel
            {
                Kp                 = movieModel.Votes.Kp,
                Imdb               = movieModel.Votes.Imdb,
                FilmCritics        = movieModel.Votes.FilmCritics,
                RussianFilmCritics = movieModel.Votes.RussianFilmCritics,
                Await              = movieModel.Votes.Await
            },
            Rating = new RatingModel
            {
                Kp                 = movieModel.Rating.Kp,
                Imdb               = movieModel.Rating.Imdb,
                FilmCritics        = movieModel.Rating.FilmCritics,
                RussianFilmCritics = movieModel.Rating.RussianFilmCritics,
                Await              = movieModel.Rating.Await
            }
        };
    }
}