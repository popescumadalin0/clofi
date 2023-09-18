using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers;

public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserRepository userRepository, ILogger<UserController> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        _logger.LogInformation("Get all users");
        var users = await _userRepository.GetUsersAsync();
        return ApiServiceResponse.ApiServiceResult(users);
    }

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

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync([FromBody] User updatedUserDto)
    {
        _logger.LogInformation($"Update user: {updatedUserDto.Id}");
        var result = await _userRepository.UpdateUserAsync(updatedUserDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        _logger.LogInformation($"Delete user: {id}");
        var result = await _userRepository.DeleteUserAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}