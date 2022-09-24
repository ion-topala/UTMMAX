using UTMMAX.Domain.Entities.User;
using UTMMAX.Framework.Models.User;

namespace UTMMAX.Framework.Mappers.UserMappers;

public class UserMapper : IUserMapper
{
    public UserEntity ToEntity(RegisterUserModel model)
    {
        return new UserEntity
        {
            FirstName = model.FirstName,
            LastName  = model.LastName,
            Email     = model.Email
        };
    }

    public UserModel ToModel(UserEntity entity)
    {
        return new UserModel
        {
            Id        = entity.Id,
            FirstName = entity.FirstName,
            LastName  = entity.LastName,
            FullName  = entity.FullName
        };
    }
}