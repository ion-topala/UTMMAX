using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Service.RepositoriesServices;

public interface IUserService : IGenericService<UserEntity>
{
    Task<UserEntity?> GetUserByEmail(string email);
}