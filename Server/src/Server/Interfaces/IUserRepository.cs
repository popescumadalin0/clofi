using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseLayout.Models;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<ICollection<Assignment>> GetAssignments(int userId);
    Task<ICollection<Note>> GetNotes(int userId);
    Task<ICollection<Alarm>> GetAlarms(int userId);
    Task<UserConfig> GetUserConfig(int userId);
}