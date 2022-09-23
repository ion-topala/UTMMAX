using Serilog;
using UTMMAX;
using UTMMAX.Migrations.Evolve;
using UTMMAX.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration));

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app            = builder.Build();
var globalAccessor = app.Services.GetRequiredService<IGlobalAccessor>();

startup.Configure(app, app.Environment, app.Lifetime);

app.UseEvolveMigrator(globalAccessor.GetConnectionString()).Wait();
app.MapControllers();

app.Run();