using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Service.Authentication;

public interface ITokenService
{
    string Generate(UserEntity user);
}

public interface IRefreshTokenServiceV2 : ITokenService
{
}

public interface IAccessTokenService : ITokenService
{
}