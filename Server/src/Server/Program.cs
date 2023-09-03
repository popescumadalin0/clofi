using System.IO;
using AutoMapperProj;
using DatabaseLayout.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server;
using Services;


var builder = WebApplication.CreateBuilder(args);
const string myAllowSpecificOrigins = "_AllowSpecificOrigins";

ConfigBuilder();

ConfigServices();

ConfigCors();

RunApp();

<<<<<<< HEAD

var myAllowSpecificOrigins = "_AllowSpecificOrigins";
builder.Services.AddCors(options =>
    {
        options.AddPolicy(myAllowSpecificOrigins, policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    }
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.SlidingExpiration = false;
    options.AccessDeniedPath = "/Forbidden/";
});
builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();


app.UseAuthentication();
app.MapDefaultControllerRoute();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
=======
void ConfigBuilder()
>>>>>>> main
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
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<ClofiContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddServices();
    builder.Services.AddRepositories();
    builder.Services.AddAutoMapperDependencies();
    builder.Services.AddControllers();
}

void ConfigCors()
{
    builder.Services.AddCors(options =>
        {
            options.AddPolicy(myAllowSpecificOrigins, policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        }
    );
}

void RunApp()
{
    var app = builder.Build();

<<<<<<< HEAD
app.Run();
=======
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseCors(myAllowSpecificOrigins);

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
>>>>>>> main
