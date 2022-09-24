using UTMMAX.Domain.Entities;
using UTMMAX.Repository.Repositories;

namespace UTMMAX.Service.Authentication;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _repository;

    public RefreshTokenService(IRefreshTokenRepository repository)
    {
        _repository = repository;
    }

    public async Task InsertRefreshToken(RefreshTokenEntity entity)
    {
        await _repository.Insert(entity);
    }

    public async Task<RefreshTokenEntity?> GetByToken(string token)
    {
        return await _repository.GetByToken(token);
    }

    public async Task DeleteByUser(int userId)
    {
        await _repository.DeleteByUser(userId);
    }
}