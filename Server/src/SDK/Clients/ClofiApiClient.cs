using Microsoft.Extensions.Logging;
using SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.DTOs;
using SDK.RefitModels;

namespace SDK.Clients;

/// <summary>
/// Here we add the endpoints for the entire application
/// </summary>
public class ClofiApiClient : RefitApiClient<IClofiApi>, IClofiApiClient
{
    private readonly IClofiApi _apiClient;

    private readonly ILogger<ClofiApiClient> _logger;

    public ClofiApiClient(IClofiApi apiClient, ILogger<ClofiApiClient> logger) : base()
    {
        _apiClient = apiClient;
        _logger = logger;
    }

    public async Task<ApiResponseMessage<List<User>>> GetUsers()
    {
        try
        {
            var task = _apiClient.GetUsers();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetUsers)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<User>> GetUser(int id)
    {
        try
        {
            var task = _apiClient.GetUser(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetUser)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteUser(int id)
    {
        try
        {
            var task = _apiClient.DeleteUser(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteUser)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateUser(User user)
    {
        try
        {
            var task = _apiClient.CreateUser(user);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateUser)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateUser(User user)
    {
        try
        {
            var task = _apiClient.UpdateUser(user);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateUser)}");
            throw;
        }
    }
}