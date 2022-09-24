namespace UTMMAX.Mvc.Extensions.Errors;

[AttributeUsage(AttributeTargets.Class)]
public class ApiAreaAttribute : Attribute
{
    public ApiAreaAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}