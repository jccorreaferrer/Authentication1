using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Repositories
{
    public interface IAppRepository
    {
        Task<App> GetByIdAsync(int appId);
        Task<IEnumerable<App>> GetAllAsync();
        Task<App> GetWithLicenseAsync(int appId);
        Task AddAsync(App app);
        Task UpdateAsync(App app);
        Task DeleteAsync(App app);
    }
}