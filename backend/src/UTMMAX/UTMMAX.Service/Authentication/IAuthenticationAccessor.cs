using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Service.Authentication;

public interface IAuthenticationAccessor
{
    int               UserId { get; }
    Task<UserEntity?> LoggedIdentity();
}