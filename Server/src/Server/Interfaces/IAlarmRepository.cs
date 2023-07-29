using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IAlarmRepository
{
    Task<ServiceResponse<List<global::Models.Alarm>>> GetAlarmsAsync();
    Task<ServiceResponse<global::Models.Alarm>> GetAlarmAsync(int id);
    Task<ServiceResponse> CreateAlarmAsync(global::Models.Alarm alarm);
    Task<ServiceResponse> UpdateAlarmAsync(global::Models.Alarm alarm);
    Task<ServiceResponse> DeleteAlarmAsync(int id);
}