﻿using Microsoft.Extensions.DependencyInjection;
using UTMMAX.Service.RepositoriesServices;
using UTMMAX.Service.Validation;

namespace UTMMAX.Service;

public static class Configurator
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IServiceModelValidator, ServiceModelValidator>();
        services.AddScoped<IPasswordService, PasswordService>();
    }
}