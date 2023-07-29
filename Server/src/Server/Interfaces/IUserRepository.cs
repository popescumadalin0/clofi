using DatabaseLayout.Models;
using SDK.Models;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> GetUsers();
    Task<ServiceResponse<bool>> AddUser(User user);
    Task<ServiceResponse<UserLoginResponse>> LoginUser(UserLoginRequest user);
}