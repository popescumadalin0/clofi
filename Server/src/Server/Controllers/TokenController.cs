using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDK.Models;
using Server.Interfaces;
using Services.Interfaces;


namespace Server.Controllers
{
    public class TokenController : BaseController
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly ICookieService _cookieService;

        public TokenController(ITokenService tokenService, IUserRepository userRepository,
            ICookieService cookieService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _cookieService = cookieService;
        }

        [HttpPost("refresh-token")]
        public IActionResult RefreshToken(UserLoginResponse request)
        {
            if (_tokenService.IsValidToken(request.RefreshToken) &&
                (_tokenService.IsValidToken(request.Token) == false))
            {
                var newToken = _tokenService.GenerateToken(request.Username, 2);
                var newRefreshToken = _tokenService.GenerateToken(request.Username,
                    _tokenService.GetExpirationTimeFromJwtInMinutes(request.RefreshToken));

                _cookieService.SetCookie("token", newToken,
                    _tokenService.GetExpirationTimeFromJwtInMinutes(newToken));

                _cookieService.SetCookie("refreshToken", newRefreshToken,
                    _tokenService.GetExpirationTimeFromJwtInMinutes(newRefreshToken));

                return new JsonResult(new { message = "Your session has been refreshed" });
            }

            if (!_tokenService.IsValidToken(request.RefreshToken))
            {
                return new JsonResult(new { message = "Your session has expired" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            return new JsonResult(new { message = "Your tokens are still active" });
        }
    }
}