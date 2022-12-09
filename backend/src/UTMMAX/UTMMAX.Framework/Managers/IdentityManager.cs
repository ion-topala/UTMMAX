using Microsoft.Extensions.Logging;
using UTMMAX.Framework.Exceptions.UserExceptions;
using UTMMAX.Framework.Mappers.UserMappers;
using UTMMAX.Framework.Models.User;
using UTMMAX.Service;
using UTMMAX.Service.Authentication;
using UTMMAX.Service.RepositoriesServices;

namespace UTMMAX.Framework.Managers;

public class IdentityManager
{
    private readonly ILogger<IdentityManager> _logger;
    private readonly IAuthenticationAccessor  _authenticationAccessor;
    private readonly IUserService             _userService;
    private readonly IUserMapper              _userMapper;
    private readonly IFileService             _fileService;

    public IdentityManager(
        ILogger<IdentityManager> logger,
        IAuthenticationAccessor  authenticationAccessor,
        IUserService             userService,
        IUserMapper              userMapper,
        IFileService             fileService)
    {
        _logger                 = logger;
        _authenticationAccessor = authenticationAccessor;
        _userService            = userService;
        _userMapper             = userMapper;
        _fileService            = fileService;
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

    public async Task<byte[]> GetProfileImage(int id)
    {
        try
        {
            var userEntity = await _userService.GetById(id);
            if (userEntity is null)
            {
                throw new UserNotFoundException();
            }

            return userEntity.ProfilePicture != null
                ? _fileService.GetImage(userEntity.ProfilePicture)
                : Array.Empty<byte>();
        }
        catch
        {
            _logger.LogError("Failed to get profile image");
            throw;
        }
    }
}