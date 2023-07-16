using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SDK.Models;
using Services.Interfaces;

namespace Services
{
    public class TokenService : ITokenService
    {
        private static IConfiguration? _configuration;

        public TokenService(IConfiguration? configuration)
        {
            _configuration = configuration;
        }

        public JwtSecurityToken GenerateToken(UserLoginRequest user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppTokenSettings:Token").Value));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credential
            );

            return token;
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
                IssuerSigningKey = key,
                ValidateIssuer = false,
                ValidateAudience = false
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

    }


}
