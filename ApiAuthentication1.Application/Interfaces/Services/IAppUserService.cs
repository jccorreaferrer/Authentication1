using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAuthentication1.Application.DTOs;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUserReadDTO>> GetAllAsync();
        Task<AppUserReadDTO> GetByIdAsync(int id);
        Task<(bool IsSuccess, string Message, AppUserReadDTO Data)> AddAsync(AppUserInsertDTO appUserInsertDTO);
        Task<(bool IsSuccess, string Message)> UpdateAsync(AppUserUpdateDTO appUserUpdateDTO);
        Task<(bool IsSuccess, string Message)> DeleteAsync(AppUserDeleteDTO appUserDeleteDTO);
        Task<(bool IsSuccess, string Message)> ChangePasswordAsync(AppUserChangePasswordDTO appUserChangePasswordDTO);

    }
}