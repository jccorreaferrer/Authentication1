using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ApiAuthentication1.Application.Interfaces.Repositories
{
    public interface IAppRoleRepository
    {
        Task<AppRole> GetByIdAsync(int appRoleId);
        Task<IEnumerable<AppRole>> GetByAppIdAsync(int appId);
        Task AddAsync(AppRole appRole);
        Task UpdateAsync(AppRole appRole);
        Task DeleteAsync(AppRole appRole);
    }
}