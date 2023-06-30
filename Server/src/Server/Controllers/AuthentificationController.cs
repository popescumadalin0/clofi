using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayout.Context;
using DatabaseLayout.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private static UserDTO loggedUser = new UserDTO();
        private readonly IConfiguration _configuration;
        private readonly ClofiContext _clofiContext;


        public AuthentificationController(IConfiguration configuration, ClofiContext clofiContext)
        {
            _configuration = configuration;
            _clofiContext = clofiContext;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegisterRequest request)
        {
            if (_clofiContext.Users.Any(user => user.Username == request.Username))
            {
                return BadRequest("User already exists");
            }
            CreateUsernameHash(request.Username, out byte[] usernameHash, out byte[] usernameSalt);

            var user = new UserDTO()
            {
                Username = request.Username,
                UsernameHash = usernameHash,
                UserNameSalt = usernameSalt,
                Password = request.Password,

            };

            _clofiContext.Users.Add(user);
            await _clofiContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginRequest request)
        {
            var getUserDto = await _clofiContext.Users.FirstOrDefaultAsync(user => user.Username == request.Username);
            if (getUserDto == null)
            {
                return BadRequest("User doesn't exist");
            }

            if (!VerifyUsernameHash(request.Username, getUserDto.UsernameHash, getUserDto.UserNameSalt))
            {
                return BadRequest("Invalid token");
            }
            loggedUser = await _clofiContext.Users.FirstOrDefaultAsync(user => user.Username == request.Username);
            string token = CreateToken(getUserDto);
            var refreshToken = CreateRefreshToken();
            SetRefreshToken(refreshToken);



            return Ok(token);
        }

        [HttpPost("RefreshToken test")]
        public async Task<ActionResult<string>> RefreshTokenTest()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!loggedUser.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid refresh token");

            }
            if (loggedUser.RefreshTokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired");
            }

            string token = CreateToken(loggedUser);
            var newRefreshToken = CreateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private RefreshToken CreateRefreshToken()
        {

            var refreshToken = new RefreshToken()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                CreatedTime = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(6)
            };
            loggedUser.RefreshToken = refreshToken.Token;
            loggedUser.RefreshTokenCreated = refreshToken.CreatedTime;
            loggedUser.RefreshTokenExpires = refreshToken.Expires;
            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

        }

        private string CreateToken(UserDTO user)
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


        private void CreateUsernameHash(string username, out byte[] usernameHash, out byte[] usernameSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                usernameSalt = hmac.Key;
                usernameHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(username));
            }
        }

        private bool VerifyUsernameHash(string username, byte[] usernameHash, byte[] usernameSalt)
        {
            using (var hmac = new HMACSHA512(usernameSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(username));
                return computeHash.SequenceEqual(usernameHash);
            }
        }

    }
}
