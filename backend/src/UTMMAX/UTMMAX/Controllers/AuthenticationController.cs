using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTMMAX.Framework.Exceptions;
using UTMMAX.Framework.Exceptions.UserExceptions;
using UTMMAX.Framework.Managers;
using UTMMAX.Framework.Models.User;
using UTMMAX.Mvc.Extensions.Errors;

namespace UTMMAX.Controllers;

[ApiArea("auth")]
[Route("api/authentication")]
public class AuthenticationController : ApiBaseController
{
    private readonly AuthenticationManager _authenticationManager;

    public AuthenticationController(AuthenticationManager authenticationManager)
    {
        _authenticationManager = authenticationManager;
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
            var userModel = await _authenticationManager.RegisterUser(model);

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
            var resultModel = await _authenticationManager.Login(model);
            return Ok(resultModel);
        }
        catch (IncorrectEmailOrPasswordException)
        {
            return BadRequest(ApiErrorCodes.Authentication.InvalidEmailOrPassword,
                ApiErrorMessage.EmailOrPasswordInvalid);
        }
    }

    [AllowAnonymous]
    [HttpPost("login-by-refresh-token")]
    [ApiAction("login-by-refresh-token")]
    public async Task<IActionResult> LoginByRefreshToken([FromBody] LoginByRefreshTokenModel model)
    {
        try
        {
            var result = await _authenticationManager.LoginByRefreshToken(model.RefreshToken);

            return Ok(result);
        }
        catch (InvalidRefreshTokenException)
        {
            var error = CreateError(ApiErrorCodes.Authentication.InvalidRefreshToken)
                .Build();
            return BadRequest(error);
        }
    }
}