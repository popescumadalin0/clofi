using Microsoft.Extensions.Logging;
using SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
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

    public async Task<ApiResponseMessage<List<User>>> GetUsersAsync()
    {
        try
        {
            var task = _apiClient.GetUsersAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetUsersAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<User>> GetUserAsync(int id)
    {
        try
        {
            var task = _apiClient.GetUserAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetUserAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteUserAsync(int id)
    {
        try
        {
            var task = _apiClient.DeleteUserAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteUserAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateUserAsync(User user)
    {
        try
        {
            var task = _apiClient.CreateUserAsync(user);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateUserAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateUserAsync(User user)
    {
        try
        {
            var task = _apiClient.UpdateUserAsync(user);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateUserAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<Alarm>>> GetAlarmsAsync()
    {
        try
        {
            var task = _apiClient.GetAlarmsAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAlarmsAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<Alarm>> GetAlarmAsync(int id)
    {
        try
        {
            var task = _apiClient.GetAlarmAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAlarmAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateAlarmAsync(Alarm alarm)
    {
        try
        {
            var task = _apiClient.CreateAlarmAsync(alarm);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateAlarmAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateAlarmAsync(Alarm alarm)
    {
        try
        {
            var task = _apiClient.UpdateAlarmAsync(alarm);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateAlarmAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteAlarmAsync(int id)
    {
        try
        {
            var task = _apiClient.DeleteAlarmAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteAlarmAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<Assignment>>> GetAssignmentsAsync()
    {
        try
        {
            var task = _apiClient.GetAssignmentsAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAssignmentsAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<Assignment>> GetAssignmentAsync(int id)
    {
        try
        {
            var task = _apiClient.GetAssignmentAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAssignmentAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateAssignmentAsync(Assignment assignment)
    {
        try
        {
            var task = _apiClient.CreateAssignmentAsync(assignment);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateAssignmentAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateAssignmentAsync(Assignment assignment)
    {
        try
        {
            var task = _apiClient.UpdateAssignmentAsync(assignment);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateAssignmentAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteAssignmentAsync(int id)
    {
        try
        {
            var task = _apiClient.DeleteAssignmentAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteAssignmentAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<Note>>> GetNotesAsync()
    {
        try
        {
            var task = _apiClient.GetNotesAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetNotesAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<Note>> GetNoteAsync(int id)
    {
        try
        {
            var task = _apiClient.GetNoteAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetNoteAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateNoteAsync(Note note)
    {
        try
        {
            var task = _apiClient.CreateNoteAsync(note);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateNoteAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateNoteAsync(Note note)
    {
        try
        {
            var task = _apiClient.UpdateNoteAsync(note);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateNoteAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteNoteAsync(int id)
    {
        try
        {
            var task = _apiClient.DeleteNoteAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteNoteAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<UserConfig>>> GetConfigsAsync()
    {
        try
        {
            var task = _apiClient.GetConfigsAsync();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetConfigsAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<UserConfig>> GetConfigAsync(int id)
    {
        try
        {
            var task = _apiClient.GetConfigAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetConfigAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateConfigAsync(UserConfig config)
    {
        try
        {
            var task = _apiClient.CreateConfigAsync(config);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateConfigAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateConfigAsync(UserConfig config)
    {
        try
        {
            var task = _apiClient.UpdateConfigAsync(config);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateConfigAsync)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteConfigAsync(int id)
    {
        try
        {
            var task = _apiClient.DeleteConfigAsync(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteConfigAsync)}");
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