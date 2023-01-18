using UTMMAX.Framework.Mappers.MovieMappers;
using UTMMAX.Framework.Models.Movie;
using UTMMAX.Kinopoisk;
using UTMMAX.Movie.Models;
using FilterModel = UTMMAX.Movie.Models.FilterModel;
using MovieModel = UTMMAX.Movie.Models.MovieModel;

namespace UTMMAX.Framework.Managers;

public class MovieManager
{
    private readonly IKinopoiskService _kinopoiskService;
    private readonly IMovieMapper      _movieMapper;

    public MovieManager(IKinopoiskService kinopoiskService, IMovieMapper movieMapper)
    {
        _kinopoiskService = kinopoiskService;
        _movieMapper      = movieMapper;
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

    public async Task<MovieResultModel[]> GetAll(MovieFilterModel filterModel)
    {
        var filter = new FilterModel
        {
            Limit = filterModel.Limit,
            Type  = filterModel.Type
        };
        var responseModel = await _kinopoiskService.GetTopByType(filter);

        return responseModel.Docs.Select(_movieMapper.Map).ToArray();
    }

    public async Task<MovieDetailsModel> GetById(long id)
    {
        return await _kinopoiskService.GetById(id);
    }
}