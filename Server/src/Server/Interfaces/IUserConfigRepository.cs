using DatabaseLayout.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IUserConfigRepository
{
    Task<UserConfig> GetUserConfig(int id);
}