using System.Net.Http;
using System.Threading.Tasks;

namespace SDK.Interfaces;

public interface IClofiApiClient
{
    /// <summary>
    /// documentation.
    /// </summary>
    /// <returns></returns>
    Task<HttpResponseMessage> GetUsers();
}