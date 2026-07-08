using EPOS.Application.Authentication.Interfaces;
using EPOS.Infrastructure.Authentication.JWT;
using EPOS.Infrastructure.Authentication.Password;
using Microsoft.Extensions.DependencyInjection;

namespace EPOS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}