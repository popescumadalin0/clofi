using DatabaseLayout.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Services.Interfaces;
using SDK.Models;
using System.IdentityModel.Tokens.Jwt;
using Server.Interfaces;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : BaseController
    {
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUserRepository _userRepository;

        public TokenController(ITokenService tokenService, IRefreshTokenService refreshTokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
            _userRepository = userRepository;
        }

        [HttpPost("refresh-token")]

        public ActionResult<UserLoginResponse> RefreshToken(UserLoginRequest request)
        {
            var token = Request.Cookies["token"];
            var refreshToken = Request.Cookies["refreshToken"];

            JwtSecurityToken tokenRequest = _tokenService.GenerateToken(request);
            JwtSecurityToken refreshTokenRequest = _refreshTokenService.GenerateRefreshToken(request);

            if (_tokenService.IsValidToken(token) && _refreshTokenService.IsValidRefreshToken(refreshToken))
            {
                var responseLogin = _userRepository.LoginUser(request);
                if (responseLogin.Result.Success.Equals(false))
                    return BadRequest("Something when wrong");
                return Ok("User " + request.Username + " is now logged");

            }
            if (!_tokenService.IsValidToken(token) && _refreshTokenService.IsValidRefreshToken(refreshToken))
            {

                var newToken = _tokenService.GenerateToken(request);
                var securityToken = new JwtSecurityTokenHandler().WriteToken(newToken);


                Response.Cookies.Append("token", securityToken, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddMinutes(5)
                });

                return Ok("Your loginToken has been refreshed");
            }
            if (!_refreshTokenService.IsValidRefreshToken(refreshToken))
            {
                return Ok("You session has expire, please login");
            }

            return Unauthorized();


        }


    }
}
