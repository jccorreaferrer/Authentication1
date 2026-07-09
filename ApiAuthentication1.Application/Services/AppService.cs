using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Mappings;
using ApiAuthentication1.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Services
{
    public class AppService : IAppService
    {
        private readonly IAppRepository _appRepository;

        public AppService(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        public async Task<IEnumerable<AppReadDTO>> GetAllAsync()
        {
            var item = await _appRepository.GetAllAsync();
            return item.Select(u => AppMapper.ToReadDTO(u));
        }
        public async Task<AppReadDTO> GetByIdAsync(int id)
        {
            var item = await _appRepository.GetByIdAsync(id);
            return AppMapper.ToReadDTO(item);
        }
        public async Task<(bool IsSuccess, string Message, AppReadDTO Data)> AddAsync(AppInsertDTO appInsertDTO)
        {
            var item = AppMapper.toApp(appInsertDTO);
            await _appRepository.AddAsync(item);
            return (true, null, AppMapper.ToReadDTO(item));

        }
        public async Task<(bool IsSuccess, string Message)> UpdateAsync(AppUpdateDTO appUpdateDTO)
        {
            var item = await _appRepository.GetByIdAsync(appUpdateDTO.AppId);
            if (item == null) return (false, $"Application with ID {appUpdateDTO.AppId} not found.");

            AppMapper.toAppUpdateDTO(item, appUpdateDTO);
            await _appRepository.UpdateAsync(item);
            return (true, null);
        }
        public async Task<(bool IsSuccess, string Message)> DeleteAsync(AppDeleteDTO appDeleteDTO)
        {
            var item = await _appRepository.GetByIdAsync(appDeleteDTO.AppId);
            if (item == null) return (false, $"Application with ID {appDeleteDTO.AppId} not found.");

            await _appRepository.DeleteAsync(item);
            return (true, null);
        }
    }
}