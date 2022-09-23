
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UTMMAX.Migrations.Evolve;

public static class Configurator
{
    public static async Task UseEvolveMigrator(this IApplicationBuilder app, string connectionString)
    {
        var service = app.ApplicationServices.GetRequiredService<MigrationService>();
        app.ApplicationServices.GetRequiredService<ILogger<MigrationService>>();
        
        await service.Migrate(connectionString);
    }
    
    public static void AddMigrations(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<MigrationService>();
    }
}