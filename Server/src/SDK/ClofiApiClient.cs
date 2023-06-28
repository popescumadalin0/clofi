using Microsoft.Extensions.Logging;
using SDK.Interfaces;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDK;

public class ClofiApiClient : RefitApiClient<IClofiApi>, IClofiApiClient
{
    private readonly IClofiApi _apiClient;

    private readonly ILogger<ClofiApiClient> _logger;

    public ClofiApiClient(IClofiApi apiClient, ILogger<ClofiApiClient> logger) : base()
    {
        _apiClient = apiClient;
        _logger = logger;
    }

    public async Task<ApiResponseMessage<bool>> GetUsers()
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
}