using Microsoft.Extensions.Logging;

namespace UTMMAX.Repository.Services;

public class DbService : IDbService
{
    private readonly ITransactionBuilder _transactionBuilder;
    private readonly ILogger<DbService>  _logger;

    public DbService(ITransactionBuilder transactionBuilder, ILogger<DbService> logger)
    {
        _transactionBuilder = transactionBuilder;
        _logger = logger;
    }

    public ITransaction BeginTransaction()
    {
        _logger.LogTrace("Opening db transaction");
        return _transactionBuilder.Begin();
    }
}