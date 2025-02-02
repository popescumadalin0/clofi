﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using SDK.RefitModels;

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
    Task<ApiResponseMessage<List<User>>> GetUsersAsync();

    /// <summary>
    /// Get user by id.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<User>> GetUserAsync(int id);

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteUserAsync(int id);

    /// <summary>
    /// Create user.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateUserAsync(User user);

    /// <summary>
    /// Update user.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateUserAsync(User user);


    /// <summary>
    /// Get all alarms.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<Alarm>>> GetAlarmsAsync();

    /// <summary>
    /// Get alarm by ID.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<Alarm>> GetAlarmAsync(int id);

    /// <summary>
    /// Create alarm.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateAlarmAsync(Alarm alarm);

    /// <summary>
    /// Update alarm.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateAlarmAsync(Alarm alarm);

    /// <summary>
    /// Delete alarm.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteAlarmAsync(int id);


    /// <summary>
    /// Get all assignments.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<Assignment>>> GetAssignmentsAsync();

    /// <summary>
    /// Get assignment by ID.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<Assignment>> GetAssignmentAsync(int id);

    /// <summary>
    /// Create assignment.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateAssignmentAsync(Assignment assignment);

    /// <summary>
    /// Update assignment.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateAssignmentAsync(Assignment assignment);

    /// <summary>
    /// Delete assignment.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteAssignmentAsync(int id);


    /// <summary>
    /// Get all notes.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<Note>>> GetNotesAsync();

    /// <summary>
    /// Get note by ID.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<Note>> GetNoteAsync(int id);

    /// <summary>
    /// Create note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateNoteAsync(Note note);

    /// <summary>
    /// Update note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateNoteAsync(Note note);

    /// <summary>
    /// Delete note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteNoteAsync(int id);


    /// <summary>
    /// Get all notes.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<List<UserConfig>>> GetConfigsAsync();

    /// <summary>
    /// Get note by ID.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<UserConfig>> GetConfigAsync(int id);

    /// <summary>
    /// Create note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> CreateConfigAsync(UserConfig config);

    /// <summary>
    /// Update note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> UpdateConfigAsync(UserConfig config);

    /// <summary>
    /// Delete note.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage> DeleteConfigAsync(int id);
}