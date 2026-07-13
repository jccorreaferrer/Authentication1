using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface ILicenseService
    {
        Task<IEnumerable<LicenseReadDTO>> GetAllAsync();
        Task<LicenseReadDTO> GetByIdAsync(int LicenseId);
        Task<LicenseReadDTO> GetByAppIdAsync(int appId);
        Task<(bool IsSuccess, string Message, LicenseReadDTO Data)> AddAsync(LicenseInsertDTO companyInsertDTO);
        Task<(bool IsSuccess, string Message)> UpdateAsync(LicenseUpdateDTO licenseUpdateDTO);
        Task<(bool IsSuccess, string Message)> DeleteAsync(LicenseDeleteDTO licenseDeleteDTO);
    }
}