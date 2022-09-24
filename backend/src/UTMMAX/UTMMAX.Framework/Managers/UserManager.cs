using UTMMAX.Framework.Models.User;
using UTMMAX.Service;
using UTMMAX.Service.RepositoriesServices;

namespace UTMMAX.Framework.Managers;

public class UserManager
{
    private readonly IServiceModelValidator _validator;
    private readonly IUserService           _userService;

    public UserManager(IServiceModelValidator validator, IUserService userService)
    {
        _validator = validator;
        _userService = userService;
    }

    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        try
        {
            // await _validator.ValidateAndThrowAsync(model);
            var userEntity = await _userService.GetUserByEmail(model.Email);
            // userEntity.ThrowINotNull(() => new UserAlreadyExistsException());

            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            throw;
        }
    }
}