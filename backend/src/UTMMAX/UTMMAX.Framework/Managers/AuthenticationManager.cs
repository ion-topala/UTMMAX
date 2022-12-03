using System.Security.Claims;
using Microsoft.Extensions.Logging;
using UTMMAX.Domain.Entities;
using UTMMAX.Domain.Entities.User;
using UTMMAX.Domain.Extensions;
using UTMMAX.Framework.Exceptions;
using UTMMAX.Framework.Exceptions.UserExceptions;
using UTMMAX.Framework.Extenstions;
using UTMMAX.Framework.Mappers.UserMappers;
using UTMMAX.Framework.Models.User;
using UTMMAX.Service;
using UTMMAX.Service.Authentication;
using UTMMAX.Service.RepositoriesServices;

namespace UTMMAX.Framework.Managers;

public class AuthenticationManager
{
    private readonly IServiceModelValidator         _validator;
    private readonly IUserService                   _userService;
    private readonly ILogger<AuthenticationManager> _logger;
    private readonly IUserMapper                    _userMapper;
    private readonly IPasswordService               _passwordService;
    private readonly ITokenGenerator                _tokenGenerator;
    private readonly ITokenBuilderService           _tokenBuilderService;
    private readonly IRefreshTokenService           _refreshTokenService;

    public AuthenticationManager(
        IServiceModelValidator         validator,
        IUserService                   userService,
        ILogger<AuthenticationManager> logger,
        IUserMapper                    userMapper,
        IPasswordService               passwordService,
        ITokenGenerator                tokenGenerator,
        ITokenBuilderService           tokenBuilderService,
        IRefreshTokenService           refreshTokenService)
    {
        _validator           = validator;
        _userService         = userService;
        _logger              = logger;
        _userMapper          = userMapper;
        _passwordService     = passwordService;
        _tokenGenerator      = tokenGenerator;
        _tokenBuilderService = tokenBuilderService;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        try
        {
            // await _validator.ValidateAndThrowAsync(model);

            model.Email = model.Email.ToLower().Trim();
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

    public async Task<LoginResultModel> Login(LoginModel loginModel)
    {
        await _validator.ValidateAndThrowAsync(loginModel);
        var user = await _userService.GetUserByEmail(loginModel.Email);

        if (user == null || !_passwordService.IsPasswordEqual(loginModel.Password, user.PasswordHash))
        {
            throw new IncorrectEmailOrPasswordException();
        }

        var token        = _tokenGenerator.GenerateToken(GetUserClaims(user));
        var refreshToken = _tokenBuilderService.GenerateRefreshToken();

        await _refreshTokenService.InsertRefreshToken(new RefreshTokenEntity
        {
            RefreshToken = refreshToken.Token,
            UserId       = user.Id,
            ExpiresTime  = refreshToken.Expires
        });

        return new LoginResultModel
        {
            AccessToken                = token.Token,
            ExpiresIn                  = token.ExpiresIn,
            TokenType                  = token.TokenType,
            RefreshToken               = refreshToken.Token,
            RefreshTokenExpirationTime = refreshToken.Expires
        };
    }

    public async Task<LoginResultModel> LoginByRefreshToken(string token)
    {
        var user         = await GetUserByRefreshToken(token);
        var accessToken  = _tokenGenerator.GenerateToken(GetUserClaims(user));
        var refreshToken = _tokenBuilderService.GenerateRefreshToken();

        if (refreshToken == null)
        {
            throw new InvalidRefreshTokenException();
        }

        await _refreshTokenService.InsertRefreshToken(new RefreshTokenEntity
        {
            RefreshToken = refreshToken.Token,
            UserId       = user.Id,
            ExpiresTime  = refreshToken.Expires
        });

        return new LoginResultModel
        {
            AccessToken                = accessToken.Token,
            ExpiresIn                  = accessToken.ExpiresIn,
            TokenType                  = accessToken.TokenType,
            RefreshToken               = refreshToken.Token,
            RefreshTokenExpirationTime = refreshToken.Expires
        };
    }

    private async Task<UserEntity> GetUserByRefreshToken(string token)
    {
        var entity = await _refreshTokenService.GetByToken(token);

        if (entity == null || entity.IsExpired())
        {
            throw new InvalidRefreshTokenException();
        }

        return entity.UserEntity ?? throw new InvalidRefreshTokenException();
    }

    private static ICollection<Claim> GetUserClaims(UserEntity userEntity)
    {
        return new Claim[]
        {
            new(ClaimType.Email, userEntity.Email),
            new(ClaimType.UserId, userEntity.Id.ToString(), ClaimValueTypes.Integer),
            new(ClaimType.FullName, $"{userEntity.FirstName} {userEntity.LastName}"),
        };
    }
}