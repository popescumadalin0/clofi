using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models.DTOs;

namespace Server.Repository;

public class UserConfigRepository : IUserConfigRepository
{
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;

    public UserConfigRepository(IClofiContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<UserConfig>>> GetConfigs()
    {
        try
        {
            var configs = await _context.UserConfigs.ToListAsync();
            var result = _mapper.Map<List<UserConfig>>(configs);
            return new ServiceResponse<List<UserConfig>>(result);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<UserConfig>>(ex);
        }
    }

    public async Task<ServiceResponse<UserConfig>> GetConfig(int id)
    {
        try
        {
            var config = await _context.UserConfigs.FindAsync(id);
            var result = _mapper.Map<UserConfig>(config);
            return new ServiceResponse<UserConfig>(result);
        }
        catch (Exception ex)
        {
            return new ServiceResponse<UserConfig>(ex);
        }
    }

    public async Task<ServiceResponse> CreateConfig(UserConfig configDto)
    {
        try
        {
            var config = _mapper.Map<DatabaseLayout.Models.UserConfig>(configDto);
            var user = await _context.Users.FindAsync(configDto.Id);
            if (user == null)
            {
                return new ServiceResponse(errorMessage: "User for this config not found!");
            }
            _context.UserConfigs.Add(config);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> UpdateConfig(UserConfig configDto)
    {
        try
        {
            var config = await _context.UserConfigs.FindAsync(configDto.Id);
            _mapper.Map(configDto, config);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> DeleteConfig(int id)
    {
        try
        {
            var config = await _context.UserConfigs.FindAsync(id);
            if (config != null)
            {
                _context.UserConfigs.Remove(config);
                await _context.SaveChangesAsync();
                return new ServiceResponse();
            }
            return new ServiceResponse(errorMessage: "UserConfig does not found!");
        }
        catch (Exception ex)
        {
            return new ServiceResponse(ex);
        }
    }
}