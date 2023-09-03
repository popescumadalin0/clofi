<<<<<<< HEAD
﻿using DatabaseLayout.Context;
using DatabaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using SDK.Models;
using Server.Interfaces;
using Server.Models;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

=======
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Server.Interfaces;
using Server.Models;
>>>>>>> main

namespace Server.Repository;

public class UserRepository : IUserRepository
{
<<<<<<< HEAD
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
=======
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;

    public UserRepository(IClofiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
            return new ServiceResponse<User>(ex);
        }
    }

    public async Task<ServiceResponse> CreateUserAsync(User userDto)
    {
        try
        {
            var user = _mapper.Map<DatabaseLayout.Models.User>(userDto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            userDto.Id = user.Id;
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            return new ServiceResponse(ex);
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
            return new ServiceResponse(ex);
        }
        
>>>>>>> main
    }
}