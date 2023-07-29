using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using SDK.Models;
using Server.Interfaces;
using Server.Models;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Server.Repository;

public class UserRepository : IUserRepository
{
    private readonly ClofiContext _context;
    private readonly ITokenService _tokenService;

    public UserRepository(ClofiContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<ICollection<User>> GetUsers()
    {
        return await _context.Users.OrderBy(u => u.Id).ToListAsync();
    }

    public async Task<ServiceResponse<bool>> AddUser(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool>(true);
        }
        catch
        {
            return new ServiceResponse<bool>(false, "Adding user failed");
        }
    }

    public async Task<ServiceResponse<UserLoginResponse>> LoginUser(UserLoginRequest request)
    {
        var checkUsername = await _context.Users.Where(u => u.Username == request.Username).ToListAsync();
        if (checkUsername.Count == 0)
        {
            return new ServiceResponse<UserLoginResponse>(new UserLoginResponse(), "Username/Password incorrect");
        }

        var checkPassword = checkUsername.FirstOrDefault(u => u.Password == request.Password);
        if (checkPassword == null)
        {
            return new ServiceResponse<UserLoginResponse>(new UserLoginResponse(), "Adding user failed");
        }

        var token = _tokenService.GenerateToken(request.Username, 2);
        var refreshToken = _tokenService.GenerateToken(request.Username, 8);

        UserLoginResponse responseLogin = new UserLoginResponse
        {
            Username = request.Username,
            Token = token,
            RefreshToken = refreshToken
        };
        return new ServiceResponse<UserLoginResponse>(responseLogin);
    }
}