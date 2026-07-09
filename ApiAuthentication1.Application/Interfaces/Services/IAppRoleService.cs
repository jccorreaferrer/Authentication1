using System.Threading.Tasks;
using System.Collections.Generic;
using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.DTOs;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface IAppRoleService
    {
        Task<AppRoleReadDTO> GetByIdAsync(int appRoleId);
        Task<IEnumerable<AppRoleReadDTO>> GetByAppIdAsync(int appId);
        Task<(bool IsSuccess, string Message, AppRoleReadDTO Data)> AddAsync(AppRoleInsertDTO appRoleInsertDTO);
        Task<(bool IsSuccess, string Message)> UpdateAsync(AppRoleUpdateDTO appRoleUpdateDTO);
        Task<(bool IsSuccess, string Message)> DeleteAsync(AppRoleDeleteDTO appRoleDeleteDTO);
    }
}