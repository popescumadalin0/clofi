using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.AspNetCore.Mvc;
using SDK.Models;
using Microsoft.Extensions.Logging;
using Server.Interfaces;
using Server.Models;
using Services;
using Services.Interfaces;
using User = Models.User;

namespace Server.Controllers;

public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;
    private readonly ICookieService _cookieService;
    private readonly ITokenService _tokenService;
    private readonly ILogger<UserConfigController> _logger;

    public UserController(IClofiContext context, IMapper mapper, IUserRepository userRepository,
        ICookieService cookieService, ITokenService tokenService, ILogger<UserConfigController> logger)
    {
        _userRepository = userRepository;
        _cookieService = cookieService;
        _tokenService = tokenService;
        _logger = logger;
    }

    [HttpGet]
    [JwtAuth]
    public async Task<IActionResult> GetUsersAsync()
    {
        _logger.LogInformation("Get all users");
        var users = await _userRepository.GetUsersAsync();
        return ApiServiceResponse.ApiServiceResult(users);
    }

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