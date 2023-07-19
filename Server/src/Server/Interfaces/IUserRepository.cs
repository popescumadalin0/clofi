using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ServiceResponse<List<global::Models.DTOs.User>>> GetUsers();
    Task<ServiceResponse<global::Models.DTOs.User>> GetUser(int id);
    Task<ServiceResponse> CreateUser(global::Models.DTOs.User user);
    Task<ServiceResponse> UpdateUser(global::Models.DTOs.User userDto);
    Task<ServiceResponse> DeleteUser(int id);
}