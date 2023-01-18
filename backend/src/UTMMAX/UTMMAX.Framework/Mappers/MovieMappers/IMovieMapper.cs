using UTMMAX.Framework.Models.Movie;
using UTMMAX.Movie.Models;

namespace UTMMAX.Framework.Mappers.MovieMappers;

public interface IMovieMapper
{
    MovieResultModel Map(MovieModel movieModel);
}