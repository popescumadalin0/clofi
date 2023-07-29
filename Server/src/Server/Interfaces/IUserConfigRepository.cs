using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IUserConfigRepository
{
    Task<ServiceResponse<List<global::Models.UserConfig>>> GetConfigsAsync();
    Task<ServiceResponse<global::Models.UserConfig>> GetConfigAsync(int id);
    Task<ServiceResponse> CreateConfigAsync(global::Models.UserConfig config);
    Task<ServiceResponse> UpdateConfigAsync(global::Models.UserConfig config);
    Task<ServiceResponse> DeleteConfigAsync(int id);
}