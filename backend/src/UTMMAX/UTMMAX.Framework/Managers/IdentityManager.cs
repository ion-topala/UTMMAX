using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using UTMMAX.Framework.Exceptions.UserExceptions;
using UTMMAX.Framework.Mappers.UserMappers;
using UTMMAX.Framework.Models.User;
using UTMMAX.Repository.Services;
using UTMMAX.Service.Authentication;
using UTMMAX.Service.RepositoriesServices;

namespace UTMMAX.Framework.Managers;

public class IdentityManager
{
    private readonly ILogger<IdentityManager> _logger;
    private readonly IRefreshTokenService     _refreshTokenService;
    private readonly IDbService               _dbService;
    private readonly IAuthorizationService    _authorizationService;
    private readonly IAuthenticationAccessor  _authenticationAccessor;
    private readonly IUserService             _userService;
    private readonly IUserMapper              _userMapper;

    public IdentityManager(
        IDbService               dbService,
        IRefreshTokenService     refreshTokenService,
        ILogger<IdentityManager> logger,
        IAuthorizationService    authorizationService,
        IAuthenticationAccessor  authenticationAccessor,
        IUserService             userService,
        IUserMapper              userMapper)
    {
        _dbService              = dbService;
        _refreshTokenService    = refreshTokenService;
        _logger                 = logger;
        _authorizationService   = authorizationService;
        _authenticationAccessor = authenticationAccessor;
        _userService            = userService;
        _userMapper             = userMapper;
    }


    public async Task<UserModel> GetCurrentSession()
    {
        var currentUser = await _authenticationAccessor.LoggedIdentity();

        if (currentUser == null)
        {
            _logger.LogInformation("User was not found");
            throw new UserNotFoundException();
        }

        _logger.LogInformation("Session was successfully got");
        return _userMapper.ToModel(currentUser);
    }

    public async Task<UserModel> GetById(int id)
    {
        try
        {
            var userEntity = await _userService.GetById(id);
            if (userEntity is null)
            {
                throw new UserNotFoundException();
            }

            var userModel = _userMapper.ToModel(userEntity);

            return userModel;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get user by id");
            throw;
        }
    }
}