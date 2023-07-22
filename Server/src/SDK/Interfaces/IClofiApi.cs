using System.Collections.Generic;
using System.Threading.Tasks;
using Models.DTOs;
using Refit;

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
}