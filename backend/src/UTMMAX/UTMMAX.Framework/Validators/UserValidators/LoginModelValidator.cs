using FluentValidation;
using UTMMAX.Framework.Models.User;
using UTMMAX.Service.Validation;

namespace UTMMAX.Framework.Validators.UserValidators;

public class LoginModelValidator : BaseValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(model => model.Email)
            .EmailAddress();

        RuleFor(model => model.Password.Length)
            .GreaterThanOrEqualTo(4);
    }
}