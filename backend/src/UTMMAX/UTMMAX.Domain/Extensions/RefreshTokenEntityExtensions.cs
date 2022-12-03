using UTMMAX.Domain.Entities;

namespace UTMMAX.Domain.Extensions;

public static class RefreshTokenEntityExtensions
{
    public static bool IsExpired(this RefreshTokenEntity entity)
    {
        return entity.ExpiresTime < DateTime.UtcNow;
    }
}