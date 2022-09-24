namespace UTMMAX.Repository.Services;

public interface ITransaction : IDisposable
{
    public void Commit();
    public Task CommitAsync();
    public void Rollback();
    public Task RollbackAsync();
}