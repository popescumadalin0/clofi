using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IAlarmRepository
{
    Task<ServiceResponse<List<global::Models.DTOs.Alarm>>> GetAlarms();
    Task<ServiceResponse<global::Models.DTOs.Alarm>> GetAlarm(int id);
    Task<ServiceResponse> CreateAlarm(global::Models.DTOs.Alarm alarm);
    Task<ServiceResponse> UpdateAlarm(global::Models.DTOs.Alarm alarm);
    Task<ServiceResponse> DeleteAlarm(int id);
}