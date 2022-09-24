namespace UTMMAX.Service.Authentication;

public interface ITokenBuilderService
{
    public RefreshToken GenerateRefreshToken();
}