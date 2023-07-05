using DatabaseLayout.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IAlarmRepository
{
    Task<ICollection<Alarm>> GetAlarms();
    Task<Alarm> GetAlarm(int id);
}