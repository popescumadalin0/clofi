using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string username, int durationMin)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppTokenSettings:Token").Value!));
        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(durationMin),
            signingCredentials: credential);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool IsValidToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppTokenSettings:Token").Value!));
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true,
        };
        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out _);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public int GetExpirationTimeFromJwtInMinutes(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwt = tokenHandler.ReadJwtToken(token);

        var remainingTime = jwt.ValidTo.Subtract(DateTime.UtcNow);
        return (int)remainingTime.TotalMinutes;
    }
}