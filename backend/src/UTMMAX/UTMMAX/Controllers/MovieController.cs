using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTMMAX.Mvc.Extensions.Errors;

namespace UTMMAX.Controllers;

[ApiArea("movie")]
[Route("api/movie")]
public class MovieController : ApiBaseController
{
    [AllowAnonymous]
    [HttpGet]
    [ApiAction("search")]
    public async Task<IActionResult> Search()
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            throw;
        }
    }
}