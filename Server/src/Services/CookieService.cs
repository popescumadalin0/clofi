using Microsoft.AspNetCore.Http;
using Server.Interfaces;
using System;

namespace Server.Repository;

public class CookieService : ICookieService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CookieService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void SetCookie(string key, string value, int? expirationInMinutes)
    {
        CookieOptions options = new CookieOptions();
        if (expirationInMinutes.HasValue)
        {
            options.Expires = DateTime.UtcNow.AddMinutes(expirationInMinutes.Value);
        }

        options.HttpOnly = true;
        _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
    }

    public string GetCookie(string key)
    {
        return _httpContextAccessor.HttpContext.Request.Cookies[key];
    }

    public void DeleteCookie(string key)
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
    }
}