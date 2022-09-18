using System.Reflection;
using UTMMAX.Core.Attributes;

namespace UTMMAX.Core.Extensions;

public static class AssemblyExtensions
{
    public static string GetVersionDescription(this Assembly assembly)
    {
        var descriptor = assembly.GetCustomAttribute<VersionDescriptionAttribute>();

        return descriptor?.VersionCode;
    }
}