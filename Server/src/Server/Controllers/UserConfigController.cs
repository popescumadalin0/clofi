using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using Server.Repository;
using System.Threading.Tasks;

namespace Server.Controllers;

public class UserConfigController : BaseController
{
    private readonly IUserConfigRepository _userConfigRepository;
    private readonly IMapper _mapper;

    public UserConfigController(IUserConfigRepository userConfigRepository, IMapper mapper)
    {
        _userConfigRepository = userConfigRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetConfigs()
    {
        var configs = await _userConfigRepository.GetConfigs();
        return ApiServiceResponse.ApiServiceResult(configs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetConfig(int id)
    {
        var config = await _userConfigRepository.GetConfig(id);
        return ApiServiceResponse.ApiServiceResult(config);
    }

    [HttpPost]
    public async Task<IActionResult> CreateConfig([FromBody] global::Models.DTOs.UserConfig newConfigDto)
    {
        var result = await _userConfigRepository.CreateConfig(newConfigDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateConfig([FromBody] global::Models.DTOs.UserConfig updatedConfigDto)
    {
        var result = await _userConfigRepository.UpdateConfig(updatedConfigDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfig(int id)
    {
        var result = await _userConfigRepository.DeleteConfig(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}