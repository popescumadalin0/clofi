using Microsoft.Extensions.Logging;
using SDK.Interfaces;
using System;
using System.Threading.Tasks;
using SDK.RefitModels;
using SDK.RefitModels.ResponseModels;

namespace SDK.Clients;

public class ClofiApiClient : RefitApiClient<IClofiApi>, IClofiApiClient
{
    private readonly IClofiApi _apiClient;

    private readonly ILogger<ClofiApiClient> _logger;

    public ClofiApiClient(IClofiApi apiClient, ILogger<ClofiApiClient> logger) : base()
    {
        _apiClient = apiClient;
        _logger = logger;
    }

    public async Task<ApiResponseMessage<UsersResponse>> GetUsers()
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