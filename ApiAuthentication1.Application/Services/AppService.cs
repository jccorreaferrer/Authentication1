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
    public class AppService : IAppService
    {
        private readonly IAppRepository _appRepository;
        private readonly ICompanyAppRepository _companyAppRepository;

        public AppService(IAppRepository appRepository, ICompanyAppRepository companyAppRepository)
        {
            _appRepository = appRepository;
            _companyAppRepository = companyAppRepository;
        }
        public async Task<IEnumerable<AppReadDTO>> GetAllAsync()
        {
            var item= await _appRepository.GetAllAsync();
            var result = new List<AppReadDTO>();

            foreach (var app in item)
            {
                var companyId = await _companyAppRepository.GetCompanyIdByAppIdAsync(app.AppId);
                if (companyId != null)
                result.Add(AppMapper.ToReadDTO(app, companyId.Value));
            }

            return result;
        }
        public async Task<AppReadDTO> GetByIdAsync(int id)
        {
            var item = await _appRepository.GetByIdAsync(id);
            if (item == null)
                return null;

            var companyId = await _companyAppRepository.GetCompanyIdByAppIdAsync(item.AppId);

            return AppMapper.ToReadDTO(item, companyId ?? 0);
        }
        public async Task<(bool IsSuccess, string Message, AppReadDTO Data)> AddAsync(AppInsertDTO appInsertDTO)
        {
            var item = AppMapper.toApp(appInsertDTO);
            item.CreationDate= DateTime.Now;
            item.CreationAppUserId = 1; 
            await _appRepository.AddAsync(item);


            var companyApp = new CompanyApp
            {
                CompanyId = appInsertDTO.CompanyId,
                AppId = item.AppId,
                IsActive = true,
                CreationDate = DateTime.Now
            };

            await _companyAppRepository.AddAsync(companyApp);
            return (true, null, AppMapper.ToReadDTO(item, appInsertDTO.CompanyId));

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