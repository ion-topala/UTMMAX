using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Framework.Models.User;
using UTMMAX.Framework.Validators.UserValidators;

namespace UTMMAX.Framework.Validators;

public static class Configurator
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidator<RegisterUserModelValidator, RegisterUserModel>();
        services.AddValidator<LoginModelValidator, LoginModel>();
    }
}