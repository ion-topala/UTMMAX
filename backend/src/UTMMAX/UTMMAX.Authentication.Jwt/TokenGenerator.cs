using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UTMMAX.Domain.Configurations;
using UTMMAX.Service.Authentication;

namespace UTMMAX.Authentication.Jwt;

public class TokenGenerator : ITokenGenerator
{
    public static readonly string                      Secret = "d5e887b5-0bab-4a10-9a1a-a9a0b51e7z0b";
    private readonly       SigningCredentials          _signingCredentials;
    private readonly       AuthenticationConfiguration _authenticationConfiguration;

    public TokenGenerator(AuthenticationConfiguration authenticationConfiguration)
    {
        _authenticationConfiguration = authenticationConfiguration;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
        _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public AccessToken GenerateToken(ICollection<Claim> claims)
    {
        var createAt = DateTime.UtcNow;

        var jwtClaims = new List<Claim>();
        jwtClaims.AddRange(claims);
        jwtClaims.Add(
            new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(createAt).ToUnixTimeSeconds().ToString())
        );
        jwtClaims.Add(
            new Claim(
                JwtRegisteredClaimNames.Exp,
                new DateTimeOffset(createAt.AddHours(4)).ToUnixTimeSeconds().ToString()
            )
        );

        var token = new JwtSecurityToken(
            "JwtIssuer",
            "JwtIssuer",
            claims: jwtClaims,
            expires: createAt.AddSeconds(_authenticationConfiguration.TokenExpirationTime),
            signingCredentials: _signingCredentials
        );

        var expiresIn = _authenticationConfiguration.TokenExpirationTime * 3600;

        return new AccessToken
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiresIn = expiresIn,
            TokenType = "Bearer"
        };
    }
}