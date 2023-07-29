using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;
using User = Models.User;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ServiceResponse<List<User>>> GetUsersAsync();
    Task<ServiceResponse<User>> GetUserAsync(int id);
    Task<ServiceResponse> CreateUserAsync(User user);
    Task<ServiceResponse> UpdateUserAsync(User userDto);
    Task<ServiceResponse> DeleteUserAsync(int id);
}