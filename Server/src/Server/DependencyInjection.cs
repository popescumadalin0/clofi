﻿using DatabaseLayout.Context;
using Microsoft.Extensions.DependencyInjection;
using Server.Interfaces;
using Server.Repository;

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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IAlarmRepository, AlarmRepository>();
        services.AddScoped<IUserConfigRepository, UserConfigRepository>();

        return services;
    }
}