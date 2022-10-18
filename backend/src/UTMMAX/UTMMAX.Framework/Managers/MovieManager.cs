using UTMMAX.Framework.Models.Movie;
using UTMMAX.Kinopoisk;
using UTMMAX.Kinopoisk.Models;

namespace UTMMAX.Framework.Managers;

public class MovieManager
{
    private readonly IKinopoiskService _kinopoiskService;

    public MovieManager(IKinopoiskService kinopoiskService)
    {
        _kinopoiskService = kinopoiskService;
    }

    public async Task<MovieModel[]> Search(SearchMovieModel model)
    {
        var responseModel = await _kinopoiskService.SearchAsync(model.SearchTerm);
        responseModel.Docs = responseModel.Docs.OrderByDescending(movieModel => movieModel.Rating.Imdb).ToArray();

        return responseModel.Docs;
    }
}