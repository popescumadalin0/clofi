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
    private readonly IMapper _mapper;

    public AlarmController(IAlarmRepository alarmRepository, IMapper mapper)
    {
        _alarmRepository = alarmRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlarms()
    {
        var alarms = await _alarmRepository.GetAlarms();
        return ApiServiceResponse.ApiServiceResult(alarms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlarm(int id)
    {
        var alarm = await _alarmRepository.GetAlarm(id);
        return ApiServiceResponse.ApiServiceResult(alarm);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAlarm([FromBody] global::Models.DTOs.Alarm newAlarmDto)
    {
        var result = await _alarmRepository.CreateAlarm(newAlarmDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAlarm([FromBody] global::Models.DTOs.Alarm updatedAlarmDto)
    {
        var result = await _alarmRepository.UpdateAlarm(updatedAlarmDto);
        return ApiServiceResponse.ApiServiceResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlarm(int id)
    {
        var result = await _alarmRepository.DeleteAlarm(id);
        return ApiServiceResponse.ApiServiceResult(result);
    }
}