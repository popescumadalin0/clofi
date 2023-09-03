<<<<<<< HEAD
﻿using DatabaseLayout.Models;
using SDK.Models;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
=======
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;
using User = Models.User;
>>>>>>> main

namespace Server.Interfaces;

public interface IUserRepository
{
<<<<<<< HEAD
    Task<ICollection<User>> GetUsers();
    Task<ServiceResponse<bool>> AddUser(User user);
    Task<ServiceResponse<UserLoginResponse>> LoginUser(UserLoginRequest user);
=======
    Task<ServiceResponse<List<User>>> GetUsersAsync();
    Task<ServiceResponse<User>> GetUserAsync(int id);
    Task<ServiceResponse> CreateUserAsync(User user);
    Task<ServiceResponse> UpdateUserAsync(User userDto);
    Task<ServiceResponse> DeleteUserAsync(int id);
>>>>>>> main
}