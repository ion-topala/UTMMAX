using UTMMAX.Domain.Entities.User;
using UTMMAX.Framework.Models.User;
using UTMMAX.Service;

namespace UTMMAX.Framework.Mappers.UserMappers;

public class UserMapper : IUserMapper
{
    private readonly IFileService _fileService;

    public UserMapper(IFileService fileService)
    {
        _fileService = fileService;
    }

    public UserEntity ToEntity(RegisterUserModel model)
    {
        return new UserEntity
        {
            FirstName = model.FirstName,
            LastName  = model.LastName,
            Email     = model.Email,
            Birthday  = model.Birthday.ToUniversalTime(),
            Gender    = model.Gender
        };
    }

    public UserModel ToModel(UserEntity entity)
    {
        string image = null;
        
        if (entity.ProfilePicture != null)
        {
            image = "data:image/jpg;base64," + _fileService.GetImage(entity.ProfilePicture);
        }

        return new UserModel
        {
            Id             = entity.Id,
            FirstName      = entity.FirstName,
            LastName       = entity.LastName,
            FullName       = entity.FullName,
            Email          = entity.Email,
            Gender         = entity.Gender,
            Birthday       = entity.Birthday,
            ProfilePicture = image
        };
    }
}