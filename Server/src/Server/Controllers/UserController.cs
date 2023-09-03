<<<<<<< HEAD
﻿using AutoMapper;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using SDK.Models;
using Server.Interfaces;
using Server.Models;
using Services;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Server.Controllers
{
    public class UserController : BaseController
    {
        private readonly IClofiContext _clofiContext;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICookieService _cookieService;
        private readonly ITokenService _tokenService;

        public UserController(IClofiContext context, IMapper mapper, IUserRepository userRepository,
            ICookieService cookieService, ITokenService tokenService)
        {
            _clofiContext = context;
            _mapper = mapper;
            _userRepository = userRepository;
            _cookieService = cookieService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [JwtAuth]
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
                Username = request.Username,
                Password = request.Password,
                Name = request.Name,
                Description = request.Description,
            };

            var response = await _userRepository.AddUser(user);

            if (response.Success)
                return Ok(user);
            return BadRequest("Error ");
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserLoginResponse>> Login(UserLoginRequest request)
        {
            var responseLogin = await _userRepository.LoginUser(request);
            if (responseLogin.Success.Equals(false))
                return BadRequest("Something when wrong");
            var token = responseLogin.Response.Token;
            var refreshToken = responseLogin.Response.RefreshToken;

            _cookieService.SetCookie("token", token, _tokenService.GetExpirationTimeFromJwtInMinutes(token));
            _cookieService.SetCookie("refreshToken", refreshToken,
                _tokenService.GetExpirationTimeFromJwtInMinutes(refreshToken));

            return Ok(responseLogin.Response);
        }
=======
﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers;

public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();
        return ApiServiceResponse.ApiServiceResult(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        var user = await _userRepository.GetUserAsync(id);
        return ApiServiceResponse.ApiServiceResult(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] User newUserDto)
    {
        var result = await _userRepository.CreateUserAsync(newUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync([FromBody] User updatedUserDto)
    {
        var result = await _userRepository.UpdateUserAsync(updatedUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        var result = await _userRepository.DeleteUserAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
>>>>>>> main
    }
}