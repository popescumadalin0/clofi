﻿using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using System.Threading.Tasks;

namespace Server.Controllers;

public class UserConfigController : BaseController
{
    private readonly IUserConfigRepository _userConfigRepository;

    public UserConfigController(IUserConfigRepository userConfigRepository)
    {
        _userConfigRepository = userConfigRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetConfigsAsync()
    {
        var configs = await _userConfigRepository.GetConfigsAsync();
        return ApiServiceResponse.ApiServiceResult(configs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetConfigAsync(int id)
    {
        var config = await _userConfigRepository.GetConfigAsync(id);
        return ApiServiceResponse.ApiServiceResult(config);
    }

    [HttpPost]
    public async Task<IActionResult> CreateConfigAsync([FromBody] global::Models.UserConfig newConfigDto)
    {
        var result = await _userConfigRepository.CreateConfigAsync(newConfigDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateConfigAsync([FromBody] global::Models.UserConfig updatedConfigDto)
    {
        var result = await _userConfigRepository.UpdateConfigAsync(updatedConfigDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfigAsync(int id)
    {
        var result = await _userConfigRepository.DeleteConfigAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}