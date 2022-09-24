using System.Security.Claims;

namespace UTMMAX.Service.Authentication;

public interface ITokenGenerator
{
    AccessToken GenerateToken(ICollection<Claim> claims);
}