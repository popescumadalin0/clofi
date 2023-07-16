using System.Threading.Tasks;
using SDK.RefitModels;
using SDK.RefitModels.ResponseModels;

namespace SDK.Interfaces;

public interface IClofiApiClient
{
    /// <summary>
    /// documentation.
    /// </summary>
    /// <returns></returns>
    Task<ApiResponseMessage<UsersResponse>> GetUsers();
}