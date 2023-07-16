using System.Collections.Generic;
using DatabaseLayout.Models;
using SDK.Models;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Interfaces
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetUsers();
        public Task<ServiceResponse<bool>> AddUser(User user);
        public Task<ServiceResponse<UserLoginResponse>> LoginUser(UserLoginRequest user);
    }
}
