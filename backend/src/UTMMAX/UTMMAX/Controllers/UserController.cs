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

    [HttpGet("{id:int}")]
    [ApiAction("get_by_id")]
    public async Task<IActionResult> Login(int id)
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}