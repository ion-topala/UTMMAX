using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UTMMAX.Service.Validation;

internal class ServiceModelValidator : IServiceModelValidator
{
    private readonly IServiceProvider        _serviceProvider;
    private readonly ILogger<ServiceModelValidator> _logger;

    public ServiceModelValidator(IServiceProvider serviceProvider, ILogger<ServiceModelValidator> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task ValidateAndThrowAsync<T>(T model, IDictionary<string, object> ctxData = null)
    {
        var validator = GetValidator<T>();

        try
        {
            await validator.ValidateAndThrowAsync(GetValidationContext(model, ctxData));
            _logger.LogDebug("Validation passed.");
        }
        catch (Exception e)
        {
            _logger.LogDebug(e, "Validation failed.");
            throw;
        }
    }

    private BaseValidator<T> GetValidator<T>()
    {
        _logger.LogTrace("Getting validator.");
        var validator = _serviceProvider.GetService<BaseValidator<T>>();
        _logger.LogDebug("Performing validation.");

        return validator;
    }

    private ValidationContext<T> GetValidationContext<T>(T model, IDictionary<string, object> ctxData = null)
    {
        var validationContext = new ValidationContext<T>(model);
        validationContext.SetServiceProvider(_serviceProvider);

        if (ctxData != null)
        {
            foreach (var key in ctxData)
            {
                validationContext.RootContextData.Add(key);
            }
        }

        return validationContext;
    }
}