using DatabaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Interfaces;

namespace Server.Controllers;

public class AlarmController : BaseController
{
    private readonly IAlarmRepository _alarmRepository;

    public AlarmController(IAlarmRepository alarmRepository)
    {
        _alarmRepository = alarmRepository;
    }
}