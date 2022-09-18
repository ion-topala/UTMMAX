using System.Net;
using System.Reflection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using UTMMAX.Core.Extensions;
using UTMMAX.Core.Json;

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
        services.AddHttpContextAccessor();
        services.AddCors();
        
        services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                // options.Filters.Add<InternalServerErrorExceptionFilter>();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddNewtonsoftJson(opts =>
            {
                DefaultSerializer.ApplyOptions(
                    DefaultSerializer.Options
                );
            });

        AddInfrastructure(services);
        AddHealthCheck(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment webHostEnvironment,
        IHostApplicationLifetime lifetime)
    {
        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        
        app.UseHealthChecks("/_health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.UseHealthChecksUI();

        app.UseAuthentication();
        app.UseAuthorization();
    }
    
    private static void AddHealthCheck(IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck("Application", () => new HealthCheckResult(HealthStatus.Healthy, "Application Build Version",
                null,
                new Dictionary<string, object>
                {
                    ["version"] = typeof(Startup).Assembly.GetVersionDescription()
                }));
        
        /*
         * /healthchecks-ui
         */
        services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(60); //time in seconds between check
                opt.MaximumHistoryEntriesPerEndpoint(15); //maximum history of checks
                opt.SetApiMaxActiveRequests(1); //api requests concurrency
        
                opt.ConfigureApiEndpointHttpclient((provider, client) =>
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
                        (sender, cert, chain, sslPolicyErrors) => true;
                });
                opt.AddHealthCheckEndpoint("UTMMAX", "/_health");
            })
            .AddInMemoryStorage();
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
}