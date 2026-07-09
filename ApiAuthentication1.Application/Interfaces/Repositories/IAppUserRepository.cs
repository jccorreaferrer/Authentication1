using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Repositories
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetByUserNameAndAppIdAsync(string userName, int appId);
        Task<AppUser> GetByEmailAndAppIdAsync(string email,  int appId);
        Task<AppUser> GetByUserNamePassAndAppIdAsync(string userName, string passwordHash, int appId);
        Task<AppUser> GetByEmailAndPassAppIdAsync(string email, string passwordHash, int appId);
        Task<AppUser> GetByIdAsync(int appUserId);
        Task<IEnumerable<AppUser>> GetAllAsync();
        Task AddAsync(AppUser appUser);
        Task UpdateAsync(AppUser appUser);
        Task DeleteAsync(AppUser appUser);
    }
}