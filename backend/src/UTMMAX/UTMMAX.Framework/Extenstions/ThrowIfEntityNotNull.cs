using System.Runtime.CompilerServices;
using Throw;
using UTMMAX.Framework.Exceptions.UserExceptions;

namespace UTMMAX.Framework.Extenstions;

public static class ThrowIfEntityNotNull
{
    public static Validatable<TValue> ThrowINotNull<TValue>(
        this TValue? value,
        Func<Exception> exceptionCustomizations = null,
        [CallerArgumentExpression("value")] string? paramName = null)
        where TValue : notnull
    {
        if (value != null)
            ExceptionThrower.ThrowNull(paramName, exceptionCustomizations);
        return new Validatable<TValue>(value, paramName, exceptionCustomizations);
    }
}