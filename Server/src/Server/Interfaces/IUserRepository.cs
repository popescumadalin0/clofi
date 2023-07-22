using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;
using User = Models.DTOs.User;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ServiceResponse<List<User>>> GetUsers();
    Task<ServiceResponse<User>> GetUser(int id);
    Task<ServiceResponse> CreateUser(User user);
    Task<ServiceResponse> UpdateUser(User userDto);
    Task<ServiceResponse> DeleteUser(int id);
}