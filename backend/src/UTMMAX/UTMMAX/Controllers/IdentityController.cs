using Microsoft.AspNetCore.Mvc;
using UTMMAX.Framework.Exceptions.UserExceptions;
using UTMMAX.Framework.Managers;
using UTMMAX.Mvc.Extensions.Errors;

namespace UTMMAX.Controllers;

[ApiArea("identity")]
[Route("api/identity")]
public class IdentityController : ApiBaseController
{
    private readonly IdentityManager _identityManager;

    public IdentityController(IdentityManager identityManager)
    {
        _identityManager = identityManager;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentSession()
    {
        try
        {
            var contextUserModel = await _identityManager.GetCurrentSession();
            return Ok(contextUserModel);
        }
        catch (UserNotFoundException)
        {
            return BadRequest(ApiErrorCodes.IdentityNotFound, ApiErrorMessage.AccountNotExists);
        }
    }

    [ApiAction("get_by_id")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var userModel = await _identityManager.GetById(id);

            return Ok(userModel);
        }
        catch (UserNotFoundException)
        {
            return BadRequest(ApiErrorCodes.IdentityNotFound, ApiErrorMessage.AccountNotExists);
        }
    }

    [ApiAction("profile-picture")]
    [HttpGet("picture/{id:int}")]
    public async Task<IActionResult> GetProfilePicture(int id)
    {
        try
        {
            var image = await _identityManager.GetProfileImage(id);
            if (image.Any())
            {
                return File(image, "image/png");
            }

            return NoContent();
        }
        catch (UserNotFoundException)
        {
            return BadRequest(ApiErrorCodes.IdentityNotFound, ApiErrorMessage.AccountNotExists);
        }
    }
}