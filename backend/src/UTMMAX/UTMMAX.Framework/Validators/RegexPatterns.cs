using System.Text.RegularExpressions;

namespace UTMMAX.Framework.Validators;

public static class RegexPatterns
{
    public static readonly Regex SecurePassword =
        new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&_])[A-Za-z\d@$!%*?&_]{8,}$");

    public static readonly Regex UsPhone = new(@"^(1\s?)?((\([0-9]{3}\))|[0-9]{3})[\s\-]?[\0-9]{3}[\s\-]?[0-9]{4}$");
}