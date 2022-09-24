using FluentValidation;
using FluentValidation.Results;

namespace UTMMAX.Service.Validation
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
        {
            if (context.InstanceToValidate != null)
            {
                return true;
            }

            result.Errors.Add(new ValidationFailure(typeof(T).Name, "Model cannot be null or empty."));
            return false;
        }
    }
}