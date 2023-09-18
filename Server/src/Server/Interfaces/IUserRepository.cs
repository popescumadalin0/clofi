using SDK.Models;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using User = Models.User;

namespace Server.Interfaces;

public interface IUserRepository
{
    Task<ServiceResponse<List<User>>> GetUsersAsync();
    Task<ServiceResponse<bool>> CreateUserAsync(User user);
    Task<ServiceResponse> UpdateUserAsync(User userDto);
    Task<ServiceResponse> DeleteUserAsync(int id);
    Task<ServiceResponse<UserLoginResponse>> LoginUserAsync(UserLoginRequest user);
    Task<ServiceResponse<bool>> RegisterUserAsync(UserRegisterRequest request);
}