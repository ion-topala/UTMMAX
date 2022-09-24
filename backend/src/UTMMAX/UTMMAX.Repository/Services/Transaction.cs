using Microsoft.EntityFrameworkCore.Storage;

namespace UTMMAX.Repository.Services;

internal class Transaction : ITransaction
{
    private readonly IDbContextTransaction _originalTransaction;
    private          bool                  _isDirty;
    private readonly Action<bool>          _txFinisher;

    public Transaction(IDbContextTransaction originalTransaction, Action<bool> txFinisher)
    {
        _originalTransaction = originalTransaction;
        _txFinisher = txFinisher;
    }

    public void Dispose()
    {
        if (!_isDirty)
        {
            Commit();
        }

        _originalTransaction?.Dispose();
    }

    public void Commit()
    {
        _originalTransaction.Commit();
        MarkAsDirty();
        _txFinisher(true);
    }

    public async Task CommitAsync()
    {
        await _originalTransaction.CommitAsync();
        MarkAsDirty();
        _txFinisher(true);
    }

    public void Rollback()
    {
        _originalTransaction.Rollback();
        MarkAsDirty();
        _txFinisher(false);
    }

    public async Task RollbackAsync()
    {
        await _originalTransaction.RollbackAsync();
        MarkAsDirty();
        _txFinisher(false);
    }

    private void MarkAsDirty()
    {
        _isDirty = true;
    }
}