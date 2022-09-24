using FluentValidation;

namespace UTMMAX.Framework.Validators;

public static class CustomValidators
{
    public static void SecurePassword<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ruleBuilder
            .Matches(RegexPatterns.SecurePassword)
            .WithMessage("'{PropertyName}' is not secure");
    }

    public static void UsNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        ruleBuilder
            .Matches(RegexPatterns.UsPhone)
            .WithMessage("Invalid phone number");
    }
}