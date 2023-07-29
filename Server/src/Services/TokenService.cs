using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services;

public class TokenService : ITokenService
{
    private static IConfiguration? _configuration;

    public TokenService(IConfiguration? configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string username, int durationMin)
    {
        byte[] usernameHash, usernameSalt;
        CreateUsernameHash(username, out usernameHash, out usernameSalt);
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usernameHash.ToString()),
            new Claim(ClaimTypes.Hash, new Guid().ToString())
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppTokenSettings:Token").Value));
        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(durationMin),
            signingCredentials: credential);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public void CreateUsernameHash(string username, out byte[] usernameHash, out byte[] usernameSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            usernameSalt = hmac.Key;
            usernameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
        }
    }

    public bool VerifyUsernameHash(string username, byte[] usernameHash, byte[] usernameSalt)
    {
        using (var hmac = new HMACSHA512(usernameSalt))
        {
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
            return computeHash.SequenceEqual(usernameHash);
        }
    }

    public bool IsValidToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppTokenSettings:Token").Value));
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
            SecurityToken validatedToken;
            tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
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

        TimeSpan remainingTime = jwt.ValidTo.Subtract(DateTime.UtcNow);
        return (int)remainingTime.TotalMinutes;
    }
}