namespace UTMMAX.Services;

public class GlobalAccessor : IGlobalAccessor
{
    public GlobalAccessor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private readonly IConfiguration _configuration;

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("DbConnection");
    }
}