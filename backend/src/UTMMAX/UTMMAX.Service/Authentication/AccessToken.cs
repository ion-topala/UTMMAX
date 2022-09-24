namespace UTMMAX.Service.Authentication;

public class AccessToken
{
    public string Token     { get; set; }
    public int    ExpiresIn { get; set; }
    public string TokenType { get; set; }
}