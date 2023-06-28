using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace SDK.Interfaces;

public interface IClofiApi
{
    [Get("/api/Client")]
    Task<bool> GetUsers();
}