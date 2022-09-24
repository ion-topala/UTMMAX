using UTMMAX.Domain.Entities.User;
using UTMMAX.Framework.Models.User;

namespace UTMMAX.Framework.Mappers.UserMappers;

public interface IUserMapper
{
    UserEntity ToEntity(RegisterUserModel model);
    UserModel  ToModel(UserEntity entity);
}