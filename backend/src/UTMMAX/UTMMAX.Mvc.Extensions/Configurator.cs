using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Mvc.Extensions.Errors;

namespace UTMMAX.Mvc.Extensions;

public static class Configurator
{
    public static void UseMvcExtensions(this IServiceCollection serviceCollection, Assembly assembly)
    {
        ApiErrorCodeComposer.InitAssemblyScan(assembly);
    }
}