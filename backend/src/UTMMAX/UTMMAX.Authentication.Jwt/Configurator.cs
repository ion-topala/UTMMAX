using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using UTMMAX.Core.Json;
using UTMMAX.Mvc.Extensions.Errors;
using UTMMAX.Service.Authentication;

namespace UTMMAX.Authentication.Jwt;

public static class Configurator
{
    public static void UseJwt(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ITokenGenerator, TokenGenerator>();
        serviceCollection.AddAuthentication(
                options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; }
            )
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "JwtIssuer",
                    ValidAudience = "JwtIssuer",
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(TokenGenerator.Secret)
                    ),
                    ClockSkew = TimeSpan.Zero,
                };
                cfg.Events = ConfigureJwtEvents();
            });
    }

    private static JwtBearerEvents ConfigureJwtEvents()
    {
        var bearerEvents = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();

                var error = ApiErrorBuilder.New("app", "generic")
                    .SetMessage("Unauthorized")
                    .SetCode(ApiErrorCodes.Unauthorized)
                    .Build();

                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(error, DefaultSerializer.Options));
            },
            OnForbidden = context =>
            {
                var error = ApiErrorBuilder.New("app", "generic")
                    .SetMessage("Forbidden")
                    .SetCode(ApiErrorCodes.Forbidden)
                    .Build();

                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(error, DefaultSerializer.Options));
            }
        };

        return bearerEvents;
    }
}