using UTMMAX.Domain.Entities.User;
using UTMMAX.Repository.Repositories;

namespace UTMMAX.Service.RepositoriesServices;

public class UserService : GenericService<UserEntity>, IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<UserEntity?> GetUserByEmail(string email)
    {
        return await _repository.GetUserByEmail(email);
    }
}