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