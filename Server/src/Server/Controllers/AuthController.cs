using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Models;
using Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public static User user = new User();
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        public AuthController(ITokenService tokenService, IRefreshTokenService refreshTokenService)

        {
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterRequest request)
        {
            _tokenService.CreateUsernameHash(request.Username, out byte[] usernameHash, out byte[] usernameSalt);
            user.Username = request.Username;
            user.Password = request.Password;
            user.UsernameHash = usernameHash;
            user.UsernameSalt = usernameSalt;
            return Ok(user);
        }

        [HttpPost("login")]

        public async Task<ActionResult<string>> Login(UserLoginRequest request)
        {
            if (user.Username != request.Username || user.Password != request.Password)
            {
                return BadRequest("Username/Password wrong");
            }

            if (!_tokenService.VerifyUsernameHash(request.Username, user.UsernameHash, user.UsernameSalt))
                return BadRequest("Invalid token");

            string token = _tokenService.GenerateToken(user);
            var refreshToken = _refreshTokenService.GenerateRefreshToken();

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);


            UserLoginResponse responseLogin = new UserLoginResponse()
            {
                Username = user.Username,
                Token = token,
                RefreshToken = refreshToken.Token
            };

            return Ok(responseLogin);
        }

    }
}
