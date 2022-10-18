using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTMMAX.Framework.Managers;
using UTMMAX.Framework.Models.Movie;
using UTMMAX.Mvc.Extensions.Errors;

namespace UTMMAX.Controllers;

[ApiArea("movie")]
[Route("api/movie")]
public class MovieController : ApiBaseController
{
    private readonly MovieManager _movieManager;

    public MovieController(MovieManager movieManager)
    {
        _movieManager = movieManager;
    }

    [AllowAnonymous]
    [HttpGet]
    [ApiAction("search")]
    public async Task<IActionResult> Search([FromBody] SearchMovieModel model)
    {
        var movies = await _movieManager.Search(model);

        return Ok(movies);
    }
}