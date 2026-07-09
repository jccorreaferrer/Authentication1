using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Repositories
{
    public interface ILicenseRepository
    {
        Task<License> GetByIdAsync(int LicenseId);
        Task<License> GetByAppIdAsync(int appId);
        Task AddAsync(License license);
        Task UpdateAsync(License license);
        Task DeleteAsync(License license);
    }
}