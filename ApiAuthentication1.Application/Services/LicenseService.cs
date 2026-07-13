using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Mappings;
using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Services
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _licenseRepository;

        public LicenseService(ILicenseRepository licenseRepository)
        {
            _licenseRepository = licenseRepository;
        }
        public async Task<IEnumerable<LicenseReadDTO>> GetAllAsync()
        {
            var items = await _licenseRepository.GetAllAsync();
            return items.Select(p => LicenseMapper.ToReadDTO(p));
        }

        public async Task<LicenseReadDTO> GetByIdAsync(int LicenseId)
        {
            var item = await _licenseRepository.GetByIdAsync(LicenseId);
            return LicenseMapper.ToReadDTO(item);
        }
        public async Task<LicenseReadDTO> GetByAppIdAsync(int appId)
        {
            var item = await _licenseRepository.GetByAppIdAsync(appId);
            return LicenseMapper.ToReadDTO(item);
        }

        public async Task<(bool IsSuccess, string Message, LicenseReadDTO Data)> AddAsync(LicenseInsertDTO licenseInsertDTO)
        {
            var item = LicenseMapper.tolicense(licenseInsertDTO);
            item.CreationDate = DateTime.Now;
            item.CreationAppUserId = 1;
            item.IsActive = true;
            await _licenseRepository.AddAsync(item);
            return (true, null, LicenseMapper.ToReadDTO(item));
        }
        public async Task<(bool IsSuccess, string Message)> UpdateAsync(LicenseUpdateDTO licenseUpdateDTO)
        {
            var item = await _licenseRepository.GetByIdAsync(licenseUpdateDTO.LicenseId);
            if (item == null) return (false, $"License with ID {licenseUpdateDTO.LicenseId} not found.");

            LicenseMapper.toLicenseUpdateDTO(item, licenseUpdateDTO);
            await _licenseRepository.UpdateAsync(item);
            return (true, null);
        }
        public async Task<(bool IsSuccess, string Message)> DeleteAsync(LicenseDeleteDTO licenseDeleteDTO)
        {
            var item = await _licenseRepository.GetByIdAsync(licenseDeleteDTO.LicenseId);
            if (item == null) return (false, $"License with ID {licenseDeleteDTO.LicenseId} not found.");

            await _licenseRepository.DeleteAsync(item);
            return (true, null);
        }
    }
}