using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string user, string password, int appId);
    }
}