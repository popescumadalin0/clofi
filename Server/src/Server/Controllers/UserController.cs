using System.Threading.Tasks;
<<<<<<< HEAD
using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDK.Models;
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
>>>>>>> main
using Server.Interfaces;
using Server.Models;
using Services;
using Services.Interfaces;
using System.Linq;
using User = Models.User;

namespace Server.Controllers;

public class UserController : BaseController
{
    private readonly IClofiContext _clofiContext;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
<<<<<<< HEAD
    private readonly ICookieService _cookieService;
    private readonly ITokenService _tokenService;

    public UserController(IClofiContext context, IMapper mapper, IUserRepository userRepository,
        ICookieService cookieService, ITokenService tokenService)
=======
    private readonly ILogger<UserController> _logger;

    public UserController(IUserRepository userRepository, ILogger<UserController> logger)
>>>>>>> main
    {
        _clofiContext = context;
        _mapper = mapper;
        _userRepository = userRepository;
<<<<<<< HEAD
        _cookieService = cookieService;
        _tokenService = tokenService;
=======
        _logger = logger;
>>>>>>> main
    }

    [HttpGet]
    [JwtAuth]
    public async Task<IActionResult> GetUsersAsync()
    {
        _logger.LogInformation("Get all users");
        var users = await _userRepository.GetUsersAsync();
        return ApiServiceResponse.ApiServiceResult(users);
    }

<<<<<<< HEAD
=======
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        _logger.LogInformation($"Get user by id: {id}");
        var user = await _userRepository.GetUserAsync(id);
        return ApiServiceResponse.ApiServiceResult(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] User newUserDto)
    {
        _logger.LogInformation("Create user");
        var result = await _userRepository.CreateUserAsync(newUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

>>>>>>> main
    [HttpPut]
    [JwtAuth]
    public async Task<IActionResult> UpdateUserAsync([FromBody] User updatedUserDto)
    {
        _logger.LogInformation($"Update user: {updatedUserDto.Id}");
        var result = await _userRepository.UpdateUserAsync(updatedUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    [JwtAuth]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        _logger.LogInformation($"Delete user: {id}");
        var result = await _userRepository.DeleteUserAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterRequest request)
    {
        var response = await _userRepository.RegisterUserAsync(request);
        return ApiServiceResponse.ApiServiceResult(response);
    }


    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginRequest request)
    {
        var responseLogin = await _userRepository.LoginUserAsync(request);
        if (responseLogin.Success.Equals(false))
            return ApiServiceResponse.ApiServiceResult(responseLogin);
        var token = responseLogin.Response.Token;
        var refreshToken = responseLogin.Response.RefreshToken;

        _cookieService.SetCookie("token", token, _tokenService.GetExpirationTimeFromJwtInMinutes(token));
        _cookieService.SetCookie("refreshToken", refreshToken,
            _tokenService.GetExpirationTimeFromJwtInMinutes(refreshToken));

        return ApiServiceResponse.ApiServiceResult(responseLogin);
    }
}