using FluentValidation;

namespace UTMMAX.Service.Validation;

public static class Extensions
{
    public static async Task ValidateAndThrowAsync<T>(
        this IValidator<T> validator,
        ValidationContext<T> context,
        CancellationToken cancellationToken = default
    )
    {
        var validationResult = await validator.ValidateAsync(context, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
    }

    public static T GetFromContext<T>(this IValidationContext context, string key)
    {
        return context.ParentContext != null
            ? (T) context.ParentContext.RootContextData[key]
            : (T) context.RootContextData[key];
    }
}