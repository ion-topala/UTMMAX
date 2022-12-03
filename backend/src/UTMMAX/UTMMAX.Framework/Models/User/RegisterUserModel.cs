using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Framework.Models.User;

public class RegisterUserModel
{
    public string   FirstName { get; set; }
    public string   LastName  { get; set; }
    public string   Email     { get; set; }
    public string   Password  { get; set; }
    public DateTime Birthday  { get; set; }
    public Gender   Gender    { get; set; }
}