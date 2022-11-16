namespace UTMMAX.Framework.Exceptions.UserExceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException()
    {
    }
    public UserNotFoundException(string? systemName) : base($"User {systemName} no found")
    {
    }
}