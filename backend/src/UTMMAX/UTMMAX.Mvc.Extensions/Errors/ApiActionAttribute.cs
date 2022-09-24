namespace UTMMAX.Mvc.Extensions.Errors;

[AttributeUsage(AttributeTargets.Method)]
public class ApiActionAttribute : Attribute
{
    public ApiActionAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}