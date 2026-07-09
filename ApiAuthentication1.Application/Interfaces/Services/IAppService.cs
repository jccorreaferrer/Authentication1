using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface IAppService
    {
        Task<IEnumerable<AppReadDTO>> GetAllAsync();
        Task<AppReadDTO> GetByIdAsync(int id); 
        Task<(bool IsSuccess, string Message, AppReadDTO Data)> AddAsync(AppInsertDTO appInsertDTO);
        Task<(bool IsSuccess, string Message)> UpdateAsync(AppUpdateDTO appUpdateDTO);
        Task<(bool IsSuccess, string Message)> DeleteAsync(AppDeleteDTO appUserDeleteDTO);
    }
}