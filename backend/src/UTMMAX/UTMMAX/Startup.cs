using System.Reflection;
using System.Text;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using UTMMAX.Authentication.Jwt;
using UTMMAX.Core.Json;
using UTMMAX.Domain.Configurations;
using UTMMAX.Files;
using UTMMAX.Framework;
using UTMMAX.Framework.Exceptions;
using UTMMAX.Kinopoisk;
using UTMMAX.Migrations.Evolve;
using UTMMAX.Mvc.Extensions;
using UTMMAX.Repository;
using UTMMAX.Service;
using UTMMAX.Services;

namespace UTMMAX;

public class Startup
{
    public Startup(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }

    private static IConfigurationRoot Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
        var globalAccessor = new GlobalAccessor(Configuration);
        services.AddSingleton<IGlobalAccessor>(_ => globalAccessor);
        
        services.AddFramework();
        services.AddRepositories();
        services.AddServices();
        services.AddHttpContextAccessor();
        services.AddMigrations();
        services.AddFileService();

        services.AddKinopoiskService(Configuration.GetSection("Kinopoisk").Get<KinopoiskConfig>());
        
        RegisterConfigurations(services);
        AddInfrastructure(services);

        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        services.AddDbContext<DataContext>(options =>
            options
                .UseExceptionProcessor()
                .UseLazyLoadingProxies()
                .UseSnakeCaseNamingConvention()
                .UseNpgsql(globalAccessor.GetConnectionString()));

        services.AddCors();
        services.UseJwt();

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add<InternalServerErrorExceptionFilter>();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddNewtonsoftJson(opts =>
            {
                DefaultSerializer.ApplyOptions(
                    DefaultSerializer.Options
                );
            });
        services.UseMvcExtensions(Assembly.GetExecutingAssembly());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment,
        IHostApplicationLifetime lifetime)
    {
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.UseAuthentication();
        app.UseAuthorization();
    }

    private static void AddInfrastructure(IServiceCollection services)
    {
        services.AddControllers(options =>
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
        services.Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
            apiBehaviorOptions.SuppressModelStateInvalidFilter = true);
        services.AddOptions();
        services.AddEndpointsApiExplorer();
    }

    private static void RegisterConfigurations(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton(ConfigurationResolver.AuthenticationConfiguration);
    }
}