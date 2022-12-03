namespace UTMMAX.Framework.Models.User;

public class LoginResultModel
{
    public string    AccessToken                { get; set; }
    public string    RefreshToken               { get; set; }
    public string    TokenType                  { get; set; }
    public int       ExpiresIn                  { get; set; }
    public DateTime? RefreshTokenExpirationTime { get; set; }
}