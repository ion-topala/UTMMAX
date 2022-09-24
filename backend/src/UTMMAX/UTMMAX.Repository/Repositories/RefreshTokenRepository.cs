using Microsoft.EntityFrameworkCore;
using UTMMAX.Domain.Entities;

namespace UTMMAX.Repository.Repositories;

public class RefreshTokenRepository : Repository<RefreshTokenEntity>, IRefreshTokenRepository
{
    public RefreshTokenRepository(DataContext context) : base(context)
    {
    }

    public async Task<RefreshTokenEntity?> GetByToken(string token)
    {
        var entity = await Table.FirstOrDefaultAsync(u => u.RefreshToken.Equals(token));
        return entity;
    }

    public async Task DeleteByUser(int id)
    {
        var table = Table;
        table = table.Where(entity => entity.UserId == id);

        if (table.Any())
        {
            await DeleteRange(table);
        }
    }
}