using Microsoft.Extensions.Logging;
using UTMMAX.Framework.Exceptions.UserExceptions;
using UTMMAX.Framework.Extenstions;
using UTMMAX.Framework.Mappers.UserMappers;
using UTMMAX.Framework.Models.User;
using UTMMAX.Service;
using UTMMAX.Service.RepositoriesServices;

namespace UTMMAX.Framework.Managers;

public class UserManager
{
    private readonly IServiceModelValidator _validator;
    private readonly IUserService           _userService;
    private readonly ILogger<UserManager>   _logger;
    private readonly IUserMapper            _userMapper;
    private readonly IPasswordService       _passwordService;

    public UserManager(IServiceModelValidator validator, IUserService userService, ILogger<UserManager> logger, IUserMapper userMapper, IPasswordService passwordService)
    {
        _validator       = validator;
        _userService     = userService;
        _logger          = logger;
        _userMapper      = userMapper;
        _passwordService = passwordService;
    }

    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        try
        {
            await _validator.ValidateAndThrowAsync(model);

            var userEntity = await _userService.GetUserByEmail(model.Email);
            userEntity.ThrowIfNotNull(() => new UserAlreadyExistsException());

            userEntity              = _userMapper.ToEntity(model);
            userEntity.PasswordHash = _passwordService.HashPassword(model.Password);
            await _userService.Insert(userEntity);

            return _userMapper.ToModel(userEntity);
        }
        catch (Exception)
        {
            _logger.LogInformation("Failed to register user");
            throw;
        }
    }
}