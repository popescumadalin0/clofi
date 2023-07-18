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
}