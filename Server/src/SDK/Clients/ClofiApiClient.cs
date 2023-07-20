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

    public async Task<ApiResponseMessage<List<Alarm>>> GetAlarms()
    {
        try
        {
            var task = _apiClient.GetAlarms();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAlarms)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<Alarm>> GetAlarm(int id)
    {
        try
        {
            var task = _apiClient.GetAlarm(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAlarm)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateAlarm(Alarm alarm)
    {
        try
        {
            var task = _apiClient.CreateAlarm(alarm);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateAlarm)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateAlarm(Alarm alarm)
    {
        try
        {
            var task = _apiClient.UpdateAlarm(alarm);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateAlarm)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteAlarm(int id)
    {
        try
        {
            var task = _apiClient.DeleteAlarm(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteAlarm)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<Assignment>>> GetAssignments()
    {
        try
        {
            var task = _apiClient.GetAssignments();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAssignments)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<Assignment>> GetAssignment(int id)
    {
        try
        {
            var task = _apiClient.GetAssignment(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetAssignment)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateAssignment(Assignment assignment)
    {
        try
        {
            var task = _apiClient.CreateAssignment(assignment);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateAssignment)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateAssignment(Assignment assignment)
    {
        try
        {
            var task = _apiClient.UpdateAssignment(assignment);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateAssignment)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteAssignment(int id)
    {
        try
        {
            var task = _apiClient.DeleteAssignment(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteAssignment)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<Note>>> GetNotes()
    {
        try
        {
            var task = _apiClient.GetNotes();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetNotes)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<Note>> GetNote(int id)
    {
        try
        {
            var task = _apiClient.GetNote(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetNote)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateNote(Note note)
    {
        try
        {
            var task = _apiClient.CreateNote(note);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateNote)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateNote(Note note)
    {
        try
        {
            var task = _apiClient.UpdateNote(note);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateNote)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteNote(int id)
    {
        try
        {
            var task = _apiClient.DeleteNote(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteNote)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<List<UserConfig>>> GetConfigs()
    {
        try
        {
            var task = _apiClient.GetConfigs();
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetConfigs)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage<UserConfig>> GetConfig(int id)
    {
        try
        {
            var task = _apiClient.GetConfig(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(GetConfig)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> CreateConfig(UserConfig config)
    {
        try
        {
            var task = _apiClient.CreateConfig(config);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(CreateConfig)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> UpdateConfig(UserConfig config)
    {
        try
        {
            var task = _apiClient.UpdateConfig(config);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(UpdateConfig)}");
            throw;
        }
    }

    public async Task<ApiResponseMessage> DeleteConfig(int id)
    {
        try
        {
            var task = _apiClient.DeleteConfig(id);
            var result = await Execute(task);
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error executing {nameof(DeleteConfig)}");
            throw;
        }
    }
}