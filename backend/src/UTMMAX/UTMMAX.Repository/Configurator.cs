using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Repository.Repositories;
using UTMMAX.Repository.Services;

namespace UTMMAX.Repository;

public static class Configurator
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        AddServices(services);
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDbService, DbService>();
        services.AddScoped<ITransactionBuilder, TransactionBuilder>();
    }
}