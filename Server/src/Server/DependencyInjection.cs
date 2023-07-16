using AutoMapperProj;
using DatabaseLayout.Context;
using Microsoft.Extensions.DependencyInjection;
using Server.Interfaces;
using Server.Repository;
using Services;
using Services.Interfaces;

namespace Server;

public static class DependencyInjection
{
    /// <summary>
    /// Add all dependencies from Server project.
    /// </summary>
    /// <param name="services">Services.</param>
    /// <returns></returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IClofiContext, ClofiContext>();
        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }

    public static IServiceCollection AddToken(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
    public static IServiceCollection AddRefreshToken(this IServiceCollection services)
    {
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        return services;
    }
    public static IServiceCollection AddUserRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}