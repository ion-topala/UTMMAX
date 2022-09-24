using FluentValidation;
using UTMMAX.Framework.Models.User;
using UTMMAX.Service.Validation;

namespace UTMMAX.Framework.Validators.UserValidators;

public class RegisterUserModelValidator : BaseValidator<RegisterUserModel>
{
    public RegisterUserModelValidator()
    {
        RuleFor(model => model.Email)
            .EmailAddress()
            .NotNull();

        RuleFor(model => model.Password)
            .SecurePassword();

        RuleFor(model => model.FirstName)
            .MaximumLength(200)
            .NotNull()
            .NotEmpty();

        RuleFor(model => model.LastName)
            .MaximumLength(200)
            .NotNull()
            .NotEmpty();
    }
}