using UTMMAX.Domain.Configurations;

namespace UTMMAX;

public static class ConfigurationResolver
{
    public static AuthenticationConfiguration AuthenticationConfiguration(IServiceProvider serviceProvider)
    {
        var configuration = serviceProvider.GetService<IConfiguration>();
        return configuration.GetSection("Authentication")
            .Get<AuthenticationConfiguration>();
    }
}