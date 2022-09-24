using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using UTMMAX.Mvc.Extensions.Errors;

namespace UTMMAX.Framework.Exceptions;

public class InternalServerErrorExceptionFilter : IExceptionFilter
{
    private readonly ILogger<InternalServerErrorExceptionFilter> _logger;

    public InternalServerErrorExceptionFilter(ILogger<InternalServerErrorExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Internal server error");

        var error = ApiErrorBuilder.New("app", "generic")
            .SetCode(ApiErrorCodes.InternalServerError)
            .SetMessage("Unexpected error occured. Please contact your Administrator.")
            .Build();
        context.ExceptionHandled = true;
        context.Result = new JsonResult(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError,
        };
    }
}