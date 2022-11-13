using Newtonsoft.Json;
using UTMMAX.Core.Json;
using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Framework.Models.User;

public class RegisterUserModel
{
    public string   FirstName { get; set; }
    public string   LastName  { get; set; }
    public string   Email     { get; set; }
    public string   Password  { get; set; }
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly Birthday  { get; set; }
    public Gender   Gender    { get; set; }
}