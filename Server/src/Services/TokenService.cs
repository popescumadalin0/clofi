using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using Models.Models;

namespace Services
{
    public class TokenService : ITokenService
    {
        private static IConfiguration? _configuration;

        public TokenService(IConfiguration? configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username)
            };
            var key = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppTokenSettings:Token").Value));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: credential
            );

            var securityToken = new JwtSecurityTokenHandler().WriteToken(token);
            return securityToken;
        }

        public void CreateUsernameHash(string username, out byte[] usernameHash, out byte[] usernameSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                usernameSalt = hmac.Key;
                usernameHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(username));
            }
        }

        public bool VerifyUsernameHash(string username, byte[] usernameHash, byte[] usernameSalt)
        {
            using (var hmac = new HMACSHA512(usernameSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(username));
                return computeHash.SequenceEqual(usernameHash);
            }
        }

    }


}
