namespace UTMMAX.Domain.Configurations
{
    public class AuthenticationConfiguration
    {
        public int TokenExpirationTime        { get; set; }
        public int RefreshTokenExpirationTime { get; set; }
    }
}