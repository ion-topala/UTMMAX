using UTMMAX.Domain.Entities;

namespace UTMMAX.Service.Authentication;

public interface IRefreshTokenService
{
    public Task                      InsertRefreshToken(RefreshTokenEntity entity);
    public Task<RefreshTokenEntity?> GetByToken(string token);
    public Task                      DeleteByUser(int userId);
}