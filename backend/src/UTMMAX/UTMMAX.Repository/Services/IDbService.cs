namespace UTMMAX.Repository.Services;

public interface IDbService
{
    public ITransaction BeginTransaction();
}