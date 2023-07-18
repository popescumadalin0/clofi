using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Server.Interfaces;
using Server.Models;

namespace Server.Repository;

public class UserRepository : IUserRepository
{
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;

    public UserRepository(IClofiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<User>>> GetUsers()
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

    public async Task<ServiceResponse<User>> GetUser(int id)
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

    public async Task<ServiceResponse> CreateUser(User userDto)
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

    public async Task<ServiceResponse> UpdateUser(User userDto)
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

    public async Task<ServiceResponse> DeleteUser(int id)
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
        
    }
}