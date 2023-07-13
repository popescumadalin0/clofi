using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;
using Models.DTOs;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ICollection<UserDTO>> GetUsers();
    Task<UserDTO> GetUser(int id);
    Task CreateUser(UserDTO user);
    Task UpdateUser(UserDTO userDto);
    Task DeleteUser(int id);
}