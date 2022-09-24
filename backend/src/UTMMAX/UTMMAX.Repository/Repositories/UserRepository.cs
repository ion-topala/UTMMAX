using Microsoft.EntityFrameworkCore;
using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Repository.Repositories;

public class UserRepository : Repository<UserEntity>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }

    public async Task<UserEntity?> GetUserByEmail(string email)
    {
        return await Table.FirstOrDefaultAsync(entity => entity.Email == email);
    }
}