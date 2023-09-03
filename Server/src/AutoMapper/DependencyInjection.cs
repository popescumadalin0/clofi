using Microsoft.Extensions.DependencyInjection;

namespace AutoMapperProj;

public static class DependencyInjection
{
    /// <summary>
    /// Add all dependencies from AutoMapper project.
    /// </summary>
    /// <param name="services">Services.</param>
    /// <returns></returns>
    public static IServiceCollection AddAutoMapperDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}