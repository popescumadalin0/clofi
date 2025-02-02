using System;
using System.IO;
using Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SDK;

var builder = WebApplication.CreateBuilder(args);

ConfigBuilder();

ConfigServices();

RunApp();

void ConfigBuilder()
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false).Build();
#else
        .AddJsonFile("appsettings.json", optional: false).Build();
#endif
    builder.Configuration.AddConfiguration(config);
}

void ConfigServices()
{
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    builder.Services.AddClofiApiClient(new Uri(builder.Configuration.GetConnectionString("ClofiApiSdk")));
    builder.Services.AddServices();
}

void RunApp()
{
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
