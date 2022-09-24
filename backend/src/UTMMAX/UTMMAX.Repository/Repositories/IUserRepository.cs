using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Repository.Repositories;

public interface IUserRepository : IRepository<UserEntity>
{
    public Task<UserEntity?> GetUserByEmail(string email);
}