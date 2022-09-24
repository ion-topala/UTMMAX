using System.Security.Cryptography;
using UTMMAX.Domain.Configurations;

namespace UTMMAX.Service.Authentication;

public class TokenBuilderService : ITokenBuilderService
{
    private readonly AuthenticationConfiguration _authenticationConfiguration;

    public TokenBuilderService(AuthenticationConfiguration authenticationConfiguration)
    {
        _authenticationConfiguration = authenticationConfiguration;
    }

    public RefreshToken GenerateRefreshToken()
    {
        using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        var randomBytes = new byte[64];
        rngCryptoServiceProvider.GetBytes(randomBytes);
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(randomBytes),
            Expires = DateTime.UtcNow.AddSeconds(_authenticationConfiguration.RefreshTokenExpirationTime),
            Created = DateTime.UtcNow
        };

        var token = refreshToken.Token;
        var expiresTime = refreshToken.Expires;
        
        return new RefreshToken
        {
            Token = token,
            Expires = expiresTime,
            Created = DateTime.UtcNow
        };
    }
}