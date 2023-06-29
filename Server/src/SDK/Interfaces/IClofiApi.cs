using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using SDK.RefitModels.ResponseModels;

namespace SDK.Interfaces;

public interface IClofiApi
{
    [Get("/api/Client")]
    Task<UsersResponse> GetUsers();
}