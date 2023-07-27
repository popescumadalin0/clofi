using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ServiceResponse<List<global::Models.User>>> GetUsersAsync();
    Task<ServiceResponse<global::Models.User>> GetUserAsync(int id);
    Task<ServiceResponse> CreateUserAsync(global::Models.User user);
    Task<ServiceResponse> UpdateUserAsync(global::Models.User userDto);
    Task<ServiceResponse> DeleteUserAsync(int id);
}