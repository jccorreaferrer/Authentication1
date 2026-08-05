using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Mappings;
using ApiAuthentication1.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Services
{
    public class AppRoleService : IAppRoleService
    {
        private readonly IAppRoleRepository _repository;
        public AppRoleService(IAppRoleRepository appRoleRepository)
        {
            _repository = appRoleRepository;
        }
        public async Task<List<AppRoleReadDTO>> GetListAsync()
        {
            var entities = await _repository.GetListAsync();
            return entities.Select(AppRoleMapper.ToReadDTO).ToList();
        }
        public async Task<AppRoleReadDTO> GetByIdAsync(int appRoleId)
        {
            var item = await _repository.GetByIdAsync(appRoleId);
            return AppRoleMapper.ToReadDTO(item);
        }
        public async Task<IEnumerable<AppRoleReadDTO>> GetByAppIdAsync(int appId)
        {
            var items = await _repository.GetByAppIdAsync(appId);
            return items.Select(p => AppRoleMapper.ToReadDTO(p));
        }
        public async Task<(bool IsSuccess, string Message, AppRoleReadDTO Data)> AddAsync(AppRoleInsertDTO appRoleInsertDTO)
        {
            var item = AppRoleMapper.toAppRole(appRoleInsertDTO);
            item.CreationDate = DateTime.Now;
            item.CreationAppUserId = 1;
            item.IsActive=true;
            await _repository.AddAsync(item);
            return (true, null, AppRoleMapper.ToReadDTO(item));
        }
        public async Task<(bool IsSuccess, string Message)> UpdateAsync(AppRoleUpdateDTO appRoleUpdateDTO)
        {
            var item = await _repository.GetByIdAsync(appRoleUpdateDTO.AppRoleId);
            if (item == null) return (false, $"Role with ID {appRoleUpdateDTO.AppRoleId} not found.");

            AppRoleMapper.toAppRoleUpdateDTO(item, appRoleUpdateDTO);
            await _repository.UpdateAsync(item);
            return (true, null);
        }
        public async Task<(bool IsSuccess, string Message)> DeleteAsync(AppRoleDeleteDTO appRoleDeleteDTO)
        {
            var item = await _repository.GetByIdAsync(appRoleDeleteDTO.AppRoleId);
            if (item == null) return (false, $"Role with ID {appRoleDeleteDTO.AppRoleId} not found.");

            await _repository.DeleteAsync(item);
            return (true, null);
        }
    }
}