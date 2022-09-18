namespace UTMMAX.Core.Attributes;

[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
public sealed class VersionDescriptionAttribute : Attribute
{
    public string VersionCode { get; }

    public VersionDescriptionAttribute(string versionCode)
    {
        VersionCode = versionCode;
    }
}