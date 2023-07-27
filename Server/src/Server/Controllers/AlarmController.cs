using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using Server.Repository;
using System.Threading.Tasks;

namespace Server.Controllers;

public class AlarmController : BaseController
{
    private readonly IAlarmRepository _alarmRepository;

    public AlarmController(IAlarmRepository alarmRepository)
    {
        _alarmRepository = alarmRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlarmsAsync()
    {
        var alarms = await _alarmRepository.GetAlarmsAsync();
        return ApiServiceResponse.ApiServiceResult(alarms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlarmAsync(int id)
    {
        var alarm = await _alarmRepository.GetAlarmAsync(id);
        return ApiServiceResponse.ApiServiceResult(alarm);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAlarmAsync([FromBody] global::Models.Alarm newAlarmDto)
    {
        var result = await _alarmRepository.CreateAlarmAsync(newAlarmDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAlarmAsync([FromBody] global::Models.Alarm updatedAlarmDto)
    {
        var result = await _alarmRepository.UpdateAlarmAsync(updatedAlarmDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlarmAsync(int id)
    {
        var result = await _alarmRepository.DeleteAlarmAsync(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}