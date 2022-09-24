using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using UTMMAX.Domain.Entities.User;
using UTMMAX.Service.RepositoriesServices;

namespace UTMMAX.Service.Authentication;

internal class HttpAuthenticationAccessor : IAuthenticationAccessor
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUserService         _userService;
    private readonly Lazy<int>            _userId;
    private          IEnumerable<Claim>   Claims => _contextAccessor.HttpContext.User.Claims;
    private          UserEntity?          _identity;

    public HttpAuthenticationAccessor(IHttpContextAccessor contextAccessor, IUserService userService)
    {
        _contextAccessor = contextAccessor;
        _userService = userService;
        _userId = new Lazy<int>(() => GetIntClaim(ClaimType.UserId));
    }

    private int GetIntClaim(string key)
    {
        var claim = Claims.FirstOrDefault(it => it.Type == key);
        var value = Convert.ToInt32(claim?.Value);

        return value;
    }

    public int UserId => _userId.Value;

    public async Task<UserEntity?> LoggedIdentity()
    {
        return _identity ??= await _userService.GetById(UserId);
    }
}