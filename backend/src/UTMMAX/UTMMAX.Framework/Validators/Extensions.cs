using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Service.Validation;

namespace UTMMAX.Framework.Validators;

public static class Extensions
{
    public static IServiceCollection AddValidator<T, TModel>(this IServiceCollection serviceCollection)
        where T : BaseValidator<TModel>
    {
        serviceCollection.AddScoped<BaseValidator<TModel>, T>();

        return serviceCollection;
    }
}