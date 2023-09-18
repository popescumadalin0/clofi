using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using SDK.Models;
=======
using Microsoft.Extensions.Logging;
using Models;
>>>>>>> main
using Server.Interfaces;
using Server.Models;
using Services.Interfaces;
using System.Linq;
using User = Models.User;

namespace Server.Repository;

public class UserRepository : IUserRepository
{
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;
<<<<<<< HEAD
    private readonly ITokenService _tokenService;

    public UserRepository(IClofiContext context, IMapper mapper, ITokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _tokenService = tokenService;
=======
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(IClofiContext context, IMapper mapper, ILogger<UserRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
>>>>>>> main
    }

    public async Task<ServiceResponse<List<User>>> GetUsersAsync()
    {
        try
        {
            var users = await _context.Users.ToListAsync();
            var result = _mapper.Map<List<User>>(users);
            return new ServiceResponse<List<User>>(result);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse<List<User>>(ex);
        }
    }

    public async Task<ServiceResponse<User>> GetUserAsync(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            var result = _mapper.Map<User>(user);
            return new ServiceResponse<User>(result);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse<User>(ex);
        }
    }

    public async Task<ServiceResponse<bool>> CreateUserAsync(User userDto)
    {
        try
        {
            var user = _mapper.Map<DatabaseLayout.Models.User>(userDto);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            userDto.Id = user.Id;
            return new ServiceResponse<bool>(true);
        }
        catch (Exception ex)
        {
<<<<<<< HEAD
            return new ServiceResponse<bool>(ex);
=======
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
>>>>>>> main
        }
    }

    public async Task<ServiceResponse> UpdateUserAsync(User userDto)
    {
        try
        {
            var user = await _context.Users.FindAsync(userDto.Id);
            _mapper.Map(userDto, user);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> DeleteUserAsync(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return new ServiceResponse();
            }

            return new ServiceResponse(errorMessage: "User does not found!");
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
<<<<<<< HEAD
    }

    public async Task<ServiceResponse<UserLoginResponse>> LoginUserAsync(UserLoginRequest request)
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

        var responseLogin = new UserLoginResponse
        {
            Username = request.Username,
            Token = token,
            RefreshToken = refreshToken
        };
        return new ServiceResponse<UserLoginResponse>(responseLogin);
    }


    public async Task<ServiceResponse<bool>> RegisterUserAsync(UserRegisterRequest request)
    {
        var checkUsername = await _context.Users.Where(u => u.Username == request.Username).ToListAsync();

        if (checkUsername.Count > 0)
        {
            return new ServiceResponse<bool>(false, "User already exists");
        }

        var user = new User()
        {
            Username = request.Username,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        var response = await CreateUserAsync(user);
        return response;
=======

>>>>>>> main
    }
}