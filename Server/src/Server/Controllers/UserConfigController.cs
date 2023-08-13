using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Models;

namespace Server.Controllers;

public class UserConfigController : BaseController
{
    private readonly IUserConfigRepository _userConfigRepository;
    private readonly ILogger<UserConfigController> _logger;

    public UserConfigController(IUserConfigRepository userConfigRepository, ILogger<UserConfigController> logger)
    {
        _userConfigRepository = userConfigRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetConfigsAsync()
    {
        _logger.LogInformation("Get all user configurations");
        var configs = await _userConfigRepository.GetConfigsAsync();
        return ApiServiceResponse.ApiServiceResult(configs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetConfigAsync(int id)
    {
        _logger.LogInformation($"Get user configuration by id: {id}");
        var config = await _userConfigRepository.GetConfigAsync(id);
        return ApiServiceResponse.ApiServiceResult(config);
    }


    [HttpGet("/user/{id}")]
    public async Task<IActionResult> GetConfigByUserAsync(int userId)
    {
        _logger.LogInformation($"Get user configuration by id: {userId}");

        //todo: get correct config for the specific user (by id or mb by username, to be discussed later)
        var config = await _userConfigRepository.GetConfigAsync(userId);
        return ApiServiceResponse.ApiServiceResult(config);
    }

    [HttpPost]
    public async Task<IActionResult> CreateConfigAsync([FromBody] UserConfig newConfigDto)
    {
        _logger.LogInformation("Create user configuration");
        var result = await _userConfigRepository.CreateConfigAsync(newConfigDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateConfigAsync([FromBody] UserConfig updatedConfigDto)
    {
        _logger.LogInformation($"Uodate user configuration: {updatedConfigDto.Id}");
        var result = await _userConfigRepository.UpdateConfigAsync(updatedConfigDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfigAsync(int id)
    {
        _logger.LogInformation($S"Delete user configuration: {id}");
        var result = await _userConfigRepository.DeleteConfigAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}