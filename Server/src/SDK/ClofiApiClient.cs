using Microsoft.Extensions.Logging;
using SDK.Interfaces;
using System;
using System.Threading.Tasks;

namespace SDK;

public class ClofiApiClient : IClofiApiClient
{
    private readonly IClofiApi _apiClient;

    private readonly ILogger<ClofiApiClient> _logger;

    public ClofiApiClient(IClofiApi apiClient, ILogger<ClofiApiClient> logger)
    {
        _apiClient = apiClient;
        _logger = logger;
    }
}