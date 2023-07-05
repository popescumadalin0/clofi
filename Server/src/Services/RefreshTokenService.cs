using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Models;
using Microsoft.AspNetCore.Http;

namespace Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        public RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddMinutes(3),
                CreateTime = DateTime.Now
            };
            return refreshToken;
        }

    }
}
