using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

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
        return services;
    }
}