using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IUserConfigRepository
{
    Task<ServiceResponse<List<global::Models.DTOs.UserConfig>>> GetConfigs();
    Task<ServiceResponse<global::Models.DTOs.UserConfig>> GetConfig(int id);
    Task<ServiceResponse> CreateConfig(global::Models.DTOs.UserConfig config);
    Task<ServiceResponse> UpdateConfig(global::Models.DTOs.UserConfig config);
    Task<ServiceResponse> DeleteConfig(int id);
}