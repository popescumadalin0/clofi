using System;
using Microsoft.AspNetCore.Http;
using Server.Interfaces;

namespace Services;

public class CookieService : ICookieService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetCookie(string key, string value, int? expirationInMinutes)
    {
        var options = new CookieOptions();
        if (expirationInMinutes.HasValue)
        {
            options.Expires = DateTime.UtcNow.AddMinutes(expirationInMinutes.Value);
        }

        options.HttpOnly = true;
        _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
    }
}