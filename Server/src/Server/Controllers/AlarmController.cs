﻿using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Server.Controllers;

public class AlarmController : BaseController
{
    private readonly IAlarmRepository _alarmRepository;
    private readonly ILogger<AlarmController> _logger;

    public AlarmController(IAlarmRepository alarmRepository, ILogger<AlarmController> logger)
    {
        _alarmRepository = alarmRepository;
        _logger = logger;
    }

    [HttpGet]
    [JwtAuth]
    public async Task<IActionResult> GetAlarmsAsync()
    {
        _logger.LogInformation("Get all alarms");
        var alarms = await _alarmRepository.GetAlarmsAsync();
        return ApiServiceResponse.ApiServiceResult(alarms);
    }

    [HttpGet("{id}")]
    [JwtAuth]
    public async Task<IActionResult> GetAlarmAsync(int id)
    {
        _logger.LogInformation($"Get alarm by id: {id}");
        var alarm = await _alarmRepository.GetAlarmAsync(id);
        return ApiServiceResponse.ApiServiceResult(alarm);
    }

    [HttpPost]
    [JwtAuth]
    public async Task<IActionResult> CreateAlarmAsync([FromBody] global::Models.Alarm newAlarmDto)
    {
        _logger.LogInformation("Create alarm");
        var result = await _alarmRepository.CreateAlarmAsync(newAlarmDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    [JwtAuth]
    public async Task<IActionResult> UpdateAlarmAsync([FromBody] global::Models.Alarm updatedAlarmDto)
    {
        _logger.LogInformation($"Update alarm: {updatedAlarmDto.Id}");
        var result = await _alarmRepository.UpdateAlarmAsync(updatedAlarmDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    [JwtAuth]
    public async Task<IActionResult> DeleteAlarmAsync(int id)
    {
        _logger.LogInformation($"Delete alarm: {id}");
        var result = await _alarmRepository.DeleteAlarmAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}