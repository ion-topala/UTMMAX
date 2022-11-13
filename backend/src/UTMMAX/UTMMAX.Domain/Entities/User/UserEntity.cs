namespace UTMMAX.Domain.Entities.User;

public class UserEntity : BaseEntity
{
    public string   FirstName    { get; set; }
    public string   LastName     { get; set; }
    public string   Email        { get; set; }
    public string   PasswordHash { get; set; }
    public DateOnly Birthday     { get; set; }
    public Gender   Gender       { get; set; }

    public string FullName =>
        string.Join(" ", new[] {FirstName, LastName}.Where(it => !string.IsNullOrWhiteSpace(it)));
}