using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Interfaces;
using System;

namespace Services;

/// <inheritdoc />
public class JwtAuthAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var services = context.HttpContext.RequestServices;
        var tokenService = (ITokenService)services.GetService(typeof(ITokenService));

        var token = context.HttpContext.Request.Cookies["token"];

        if (tokenService.IsValidToken(token)) return;
        context.Result = new JsonResult(new { message = "Unauthorized" })
        {
            StatusCode = StatusCodes.Status401Unauthorized
        };
    }
}