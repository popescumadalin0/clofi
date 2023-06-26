using System;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SDK.Interfaces;

namespace SDK;

/// <summary />
public static class DependencyInjectionExtS
{
    /// <summary />
    public static IServiceCollection AddClofiApiClient(this IServiceCollection services, Uri url)
    {
        services.AddRefitClient<IClofiApi>()
            .ConfigureHttpClient(c => c.BaseAddress = url);

        services.AddSingleton<IClofiApiClient, ClofiApiClient>();
        return services;
    }
}