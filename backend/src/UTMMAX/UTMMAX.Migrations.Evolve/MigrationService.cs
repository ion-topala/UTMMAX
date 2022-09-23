using System.Reflection;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace UTMMAX.Migrations.Evolve;

public class MigrationService
{
    private readonly ILogger<MigrationService> _logger;

    public MigrationService(ILogger<MigrationService> logger)
    {
        _logger = logger;
    }

    public Task Migrate(string connectionString)
    {
        try
        {
            var pathDirectory = GetAllMigrationsDirectoryPath();
            var cnx           = new NpgsqlConnection(connectionString);
            var evolve = new global::Evolve.Evolve(cnx, msg => _logger.LogInformation(msg))
            {
                Locations       = new[] {pathDirectory},
                IsEraseDisabled = true,
                OutOfOrder      = true
            };

            evolve.Migrate();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Database migration failed.");
            throw;
        }

        return Task.CompletedTask;
    }

    private static string GetAllMigrationsDirectoryPath()
    {
        var assemblyPath      = Assembly.GetExecutingAssembly().Location;
        var assemblyDirectory = Path.GetDirectoryName(assemblyPath);
        var directory         = new DirectoryInfo(assemblyDirectory);
        var filesPath         = Path.Combine(directory.FullName, "PostgresMigrations");

        return filesPath;
    }
}