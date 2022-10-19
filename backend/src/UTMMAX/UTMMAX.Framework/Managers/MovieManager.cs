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
        var filter = new FilterModel
        {
            SearchTerm = model.SearchTerm,
            Limit      = model.Limit
        };

        var responseModel = await _kinopoiskService.SearchAsync(filter);
        responseModel.Docs = responseModel.Docs.OrderByDescending(movieModel => movieModel.Rating.Imdb)
                                          .Take(filter.Limit)
                                          .ToArray();

        return responseModel.Docs;
    }

    public async Task<MovieModel[]> GetAll(MovieFilterModel filterModel)
    {
        var filter = new FilterModel
        {
            Limit = filterModel.Limit,
            Type  = filterModel.Type
        };
        var responseModel = await _kinopoiskService.GetTopByType(filter);

        return responseModel.Docs;
    }
}