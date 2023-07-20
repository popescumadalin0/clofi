using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models.DTOs;
using Refit;
using SDK.RefitModels;
using SDK.RefitModels.ResponseModels;

namespace SDK.Interfaces;

/// <summary>
/// Here we add the endpoints for the entire application
/// </summary>
public interface IClofiApiClient
{
    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<User>>> GetUsers();

    /// <summary>
    /// Get user by id.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<User>> GetUser(int id);

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteUser(int id);

    /// <summary>
    /// Create user.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateUser(User user);

    /// <summary>
    /// Update user.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateUser(User user);


    /// <summary>
    /// Get all alarms.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<Alarm>>> GetAlarms();

    /// <summary>
    /// Get alarm by ID.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<Alarm>> GetAlarm(int id);

    /// <summary>
    /// Create alarm.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateAlarm(Alarm alarm);

    /// <summary>
    /// Update alarm.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateAlarm(Alarm alarm);
    
    /// <summary>
    /// Delete alarm.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteAlarm(int id);


    /// <summary>
    /// Get all assignments.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<Assignment>>> GetAssignments();

    /// <summary>
    /// Get assignment by ID.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<Assignment>> GetAssignment(int id);

    /// <summary>
    /// Create assignment.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateAssignment(Assignment assignment);

    /// <summary>
    /// Update assignment.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateAssignment(Assignment assignment);

    /// <summary>
    /// Delete assignment.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteAssignment(int id);


    /// <summary>
    /// Get all notes.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<Note>>> GetNotes();

    /// <summary>
    /// Get note by ID.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<Note>> GetNote(int id);

    /// <summary>
    /// Create note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateNote(Note note);

    /// <summary>
    /// Update note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateNote(Note note);

    /// <summary>
    /// Delete note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteNote(int id);


    /// <summary>
    /// Get all notes.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<UserConfig>>> GetConfigs();

    /// <summary>
    /// Get note by ID.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<UserConfig>> GetConfig(int id);

    /// <summary>
    /// Create note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateConfig(UserConfig config);

    /// <summary>
    /// Update note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateConfig(UserConfig config);

    /// <summary>
    /// Delete note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteConfig(int id);
}