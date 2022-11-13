using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTMMAX.Framework.Managers;
using UTMMAX.Framework.Models.User;
using UTMMAX.Mvc.Extensions.Errors;

namespace UTMMAX.Controllers;

[ApiArea("identity")]
[Route("api/identity")]
public class UserController : ApiBaseController
{
    private readonly UserManager _userManager;

    public UserController(UserManager userManager)
    {
        _userManager = userManager;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    [ApiAction("register")]
    [ProducesResponseType(200, Type = typeof(UserModel))]
    [ProducesResponseType(400, Type = typeof(ApiErrorModel))]
    public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
    {
        try
        {
            var userModel = await _userManager.RegisterUser(model);

            return Ok(userModel);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ApiAction("login")]
    [ProducesResponseType(200, Type = typeof(LoginResultModel))]
    [ProducesResponseType(400, Type = typeof(ApiErrorModel))]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        try
        {
            var resultModel = await _userManager.Login(model);
            return Ok(resultModel);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}