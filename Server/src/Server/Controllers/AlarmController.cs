using AutoMapper.Configuration;
using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Server.Interfaces;

namespace Server.Controllers;

public class AlarmController : BaseController
{
    private readonly IAlarmRepository _alarmRepository;

    public AlarmController(IAlarmRepository alarmRepository)
    {
        _alarmRepository = alarmRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Alarm>))]
    public async Task<IActionResult> GetAlarms()
    {
        var alarms = await _alarmRepository.GetAlarms();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(alarms);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Note))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAssignment(int id)
    {
        var alarm = await _alarmRepository.GetAlarm(id);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(alarm);
    }
}