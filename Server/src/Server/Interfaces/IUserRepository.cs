using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Models.DTOs;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ICollection<global::Models.DTOs.User>> GetUsers();
    Task<global::Models.DTOs.User> GetUser(int id);
    Task CreateUser(global::Models.DTOs.User user);
    Task UpdateUser(global::Models.DTOs.User userDto);
    Task DeleteUser(int id);
}