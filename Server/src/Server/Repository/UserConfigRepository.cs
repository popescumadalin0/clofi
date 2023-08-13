using AutoMapper;
using DatabaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Server.Interfaces;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Models;
using Microsoft.Extensions.Logging;

namespace Server.Repository;

public class UserConfigRepository : IUserConfigRepository
{
    private readonly IClofiContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<UserConfigRepository> _logger;

    public UserConfigRepository(IClofiContext context, IMapper mapper, ILogger<UserConfigRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ServiceResponse<List<UserConfig>>> GetConfigsAsync()
    {
        try
        {
            var configs = await _context.UserConfigs.ToListAsync();
            var result = _mapper.Map<List<UserConfig>>(configs);
            return new ServiceResponse<List<UserConfig>>(result);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse<List<UserConfig>>(ex);
        }
    }

    public async Task<ServiceResponse<UserConfig>> GetConfigAsync(int id)
    {
        try
        {
            var config = await _context.UserConfigs.FindAsync(id);
            var result = _mapper.Map<UserConfig>(config);
            return new ServiceResponse<UserConfig>(result);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse<UserConfig>(ex);
        }
    }

    public async Task<ServiceResponse> CreateConfigAsync(UserConfig configDto)
    {
        try
        {
            var config = _mapper.Map<DatabaseLayout.Models.UserConfig>(configDto);
            var user = await _context.Users.FindAsync(configDto.Id);
            if (user == null)
            {
                _logger.LogInformation("User for this config not found!");
                return new ServiceResponse(errorMessage: "User for this config not found!");
            }
            _context.UserConfigs.Add(config);
            await _context.SaveChangesAsync();
            return new ServiceResponse();
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> UpdateConfigAsync(UserConfig configDto)
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
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
    }

    public async Task<ServiceResponse> DeleteConfigAsync(int id)
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

            _logger.LogInformation("UserConfig does not found!");
            return new ServiceResponse(errorMessage: "UserConfig does not found!");
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return new ServiceResponse(ex);
        }
    }
}