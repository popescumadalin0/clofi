using Microsoft.Extensions.DependencyInjection;
using Server.Interfaces;
using Services.Interfaces;

namespace Services;

public static class DependencyInjection
{
    /// <summary>
    /// Add all dependencies from Server project.
    /// </summary>
    /// <param name="services">Services.</param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICookieService, CookieService>();
        return services;
    }
}