using System.ComponentModel;
using UTMMAX.Kinopoisk.Enums;

namespace UTMMAX.Kinopoisk.Extensions;

public static class MovieTypeExtension
{
    public static string ToDescriptionString(this MovieType val)
    {
        var attributes =
            (DescriptionAttribute[]) val
                                     .GetType()
                                     .GetField(val.ToString())
                                     ?.GetCustomAttributes(typeof(DescriptionAttribute), false)!;
        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
}