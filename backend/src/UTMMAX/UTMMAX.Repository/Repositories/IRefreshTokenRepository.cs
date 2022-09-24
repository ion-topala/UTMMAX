using UTMMAX.Domain.Entities;

namespace UTMMAX.Repository.Repositories;

public interface IRefreshTokenRepository : IRepository<RefreshTokenEntity>
{
    Task<RefreshTokenEntity?> GetByToken(string token);
    Task                      DeleteByUser(int id);
}