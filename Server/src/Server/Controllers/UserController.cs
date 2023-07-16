using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using SDK.Models;
using Server.Interfaces;
using Server.Models;


namespace Server.Controllers
{
    public class UserController : BaseController
    {
        private readonly IClofiContext _clofiContext;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IClofiContext context, IMapper mapper, IUserRepository userRepository)
        {
            _clofiContext = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            _ = await _clofiContext.Users.AddAsync(new User()
            {
                Description = "test user",
                Name = "test",
                Username = "test_username"
            });
            await _clofiContext.SaveChangesAsync();
            var users = await _clofiContext.Users.ToListAsync();

            var usersResult = _mapper.Map<List<UserDTO>>(users);
            return ApiServiceResponse.ApiServiceResult(new ServiceResponse<List<UserDTO>>(usersResult));
        }

        [HttpPost("Register")]

        public async Task<ActionResult<User>> Register(UserRegisterRequest request)
        {

            var checkUsername = await _clofiContext.Users.Where(u => u.Username == request.Username).ToListAsync();

            if (checkUsername.Count > 0)
            {
                return BadRequest("User already taken");
            }

            var user = new User()
            {
                Description = "register user",
                Name = "test register",
                Username = request.Username,
                Password = request.Password,
            };

            var response = _userRepository.AddUser(user);

            if (response.Result.Success)
                return Ok(user);
            return BadRequest("Error ");
        }


        [HttpPost("Login")]

        public async Task<ActionResult<string>> Login(UserLoginRequest request)
        {

            var responseLogin = _userRepository.LoginUser(request);
            if (responseLogin.Result.Success.Equals(false))
                return BadRequest("Something when wrong");
            var token = responseLogin.Result.Response.Token;
            var refreshToken = responseLogin.Result.Response.RefreshToken;

            var TokenKey = new JwtSecurityTokenHandler().WriteToken(token);
            var RefreshTokenKey = new JwtSecurityTokenHandler().WriteToken(refreshToken);

            var cookieOptionsToken = new CookieOptions
            {
                HttpOnly = true,
                Expires = token.ValidTo
            };
            Response.Cookies.Append("token", TokenKey, cookieOptionsToken);

            var cookieOptionsRefreshToken = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.ValidTo
            };
            Response.Cookies.Append("refreshToken", RefreshTokenKey, cookieOptionsRefreshToken);

            return Ok("User " + request.Username + " is now logged");
        }
    }
}
