using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Mappings;

namespace ApiAuthentication1.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyReadDTO>> GetAllAsync()
        {
            var items = await _companyRepository.GetAllAsync();
            return items.Select(p => CompanyMapper.ToReadDTO(p));
        }

        public async Task<CompanyReadDTO> GetByIdAsync(int companyId)
        {
            var item = await _companyRepository.GetByIdAsync(companyId);
            return CompanyMapper.ToReadDTO(item);
        }

        public async Task<(bool IsSuccess, string Message, CompanyReadDTO Data)> AddAsync(CompanyInsertDTO companyInsertDTO)
        {
            var item = CompanyMapper.toCompany(companyInsertDTO);
            item.CreationDate= DateTime.Now;
            item.CreationAppUserId = 1;
            item.IsActive = true;
            await _companyRepository.AddAsync(item);
            return (true, null, CompanyMapper.ToReadDTO(item));
        }

        public async Task<(bool IsSuccess, string Message)> UpdateAsync(CompanyUpdateDTO companyUpdateDTO)
        {
            var item = await _companyRepository.GetByIdAsync(companyUpdateDTO.CompanyId);
            if (item == null) return (false, $"Company with ID {companyUpdateDTO.CompanyId} not found.");

            CompanyMapper.toCompanyUpdateDTO(item, companyUpdateDTO);
            await _companyRepository.UpdateAsync(item);
            return (true, null);
        }

        public async Task<(bool IsSuccess, string Message)> DeleteAsync(CompanyDeleteDTO companyDeleteDTO)
        {
            var item = await _companyRepository.GetByIdAsync(companyDeleteDTO.CompanyId);
            if (item == null) return (false, $"Company with ID {companyDeleteDTO.CompanyId} not found.");

            await _companyRepository.DeleteAsync(item);
            return (true, null);
        }

        public string GetConnectionStrignDB()
        {
            return _companyRepository.GetConnectionStrignDB();
        }
    }
}