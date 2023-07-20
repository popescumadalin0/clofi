using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models.DTOs;
using Refit;
using SDK.RefitModels.ResponseModels;

namespace SDK.Interfaces;

/// <summary>
/// Here we add the endpoints for the entire application
/// </summary>
public interface IClofiApi
{
    [Get("/api/User")]
    Task<List<User>> GetUsers();

    [Get("/api/User/{id}")]
    Task<User> GetUser(int id);

    [Delete("/api/User/{id}")]
    Task DeleteUser(int id);

    [Post("/api/User")]
    Task CreateUser(User user);

    [Put("/api/User")]
    Task UpdateUser(User user);


    [Get("/api/Alarm")]
    Task<List<Alarm>> GetAlarms();

    [Get("/api/Alarm/{id}")]
    Task<Alarm> GetAlarm(int id);

    [Post("/api/Alarm")]
    Task CreateAlarm(Alarm alarm);

    [Put("/api/Alarm")]
    Task UpdateAlarm(Alarm alarm);

    [Delete("/api/Alarm/{id}")]
    Task DeleteAlarm(int id);


    [Get("/api/Assignment")]
    Task<List<Assignment>> GetAssignments();

    [Get("/api/Assignment/{id}")]
    Task<Assignment> GetAssignment(int id);

    [Post("/api/Assignment")]
    Task CreateAssignment(Assignment assignment);

    [Put("/api/Assignment")]
    Task UpdateAssignment(Assignment assignment);

    [Delete("/api/Assignment/{id}")]
    Task DeleteAssignment(int id);


    [Get("/api/Note")]
    Task<List<Note>> GetNotes();

    [Get("/api/Note/{id}")]
    Task<Note> GetNote(int id);

    [Post("/api/Note")]
    Task CreateNote(Note note);

    [Put("/api/Note")]
    Task UpdateNote(Note note);

    [Delete("/api/Note/{id}")]
    Task DeleteNote(int id);


    [Get("/api/UserConfig")]
    Task<List<UserConfig>> GetConfigs();

    [Get("/api/UserConfig/{id}")]
    Task<UserConfig> GetConfig(int id);

    [Post("/api/UserConfig")]
    Task CreateConfig(UserConfig config);

    [Put("/api/UserConfig")]
    Task UpdateConfig(UserConfig config);

    [Delete("/api/UserConfig/{id}")]
    Task DeleteConfig(int id);
}