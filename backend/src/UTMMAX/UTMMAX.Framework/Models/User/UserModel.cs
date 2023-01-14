using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Framework.Models.User;

public class UserModel
{
    public int      Id             { get; set; }
    public string   FirstName      { get; set; }
    public string   LastName       { get; set; }
    public string   FullName       { get; set; }
    public string   Email          { get; set; }
    public DateTime Birthday       { get; set; }
    public Gender   Gender         { get; set; }
    public string?  ProfilePicture { get; set; }
}