using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Refit;

namespace SDK.Interfaces;

/// <summary>
/// Here we add the endpoints for the entire application
/// </summary>
public interface IClofiApi
{
    [Get("/api/User")]
    Task<List<User>> GetUsersAsync();

    [Get("/api/User/{id}")]
    Task<User> GetUserAsync(int id);

    [Delete("/api/User/{id}")]
    Task DeleteUserAsync(int id);

    [Post("/api/User")]
    Task CreateUserAsync(User user);

    [Put("/api/User")]
    Task UpdateUserAsync(User user);


    [Get("/api/Alarm")]
    Task<List<Alarm>> GetAlarmsAsync();

    [Get("/api/Alarm/{id}")]
    Task<Alarm> GetAlarmAsync(int id);

    [Post("/api/Alarm")]
    Task CreateAlarmAsync(Alarm alarm);

    [Put("/api/Alarm")]
    Task UpdateAlarmAsync(Alarm alarm);

    [Delete("/api/Alarm/{id}")]
    Task DeleteAlarmAsync(int id);


    [Get("/api/Assignment")]
    Task<List<Assignment>> GetAssignmentsAsync();

    [Get("/api/Assignment/{id}")]
    Task<Assignment> GetAssignmentAsync(int id);

    [Post("/api/Assignment")]
    Task CreateAssignmentAsync(Assignment assignment);

    [Put("/api/Assignment")]
    Task UpdateAssignmentAsync(Assignment assignment);

    [Delete("/api/Assignment/{id}")]
    Task DeleteAssignmentAsync(int id);


    [Get("/api/Note")]
    Task<List<Note>> GetNotesAsync();

    [Get("/api/Note/{id}")]
    Task<Note> GetNoteAsync(int id);

    [Post("/api/Note")]
    Task CreateNoteAsync(Note note);

    [Put("/api/Note")]
    Task UpdateNoteAsync(Note note);

    [Delete("/api/Note/{id}")]
    Task DeleteNoteAsync(int id);


    [Get("/api/UserConfig")]
    Task<List<UserConfig>> GetConfigsAsync();

    [Get("/api/UserConfig/{id}")]
    Task<UserConfig> GetConfigAsync(int id);

    [Post("/api/UserConfig")]
    Task CreateConfigAsync(UserConfig config);

    [Put("/api/UserConfig")]
    Task UpdateConfigAsync(UserConfig config);

    [Delete("/api/UserConfig/{id}")]
    Task DeleteConfigAsync(int id);
}