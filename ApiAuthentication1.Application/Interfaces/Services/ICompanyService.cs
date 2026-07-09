using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyReadDTO>> GetAllAsync();
        Task<CompanyReadDTO> GetByIdAsync(int companyId);
        Task<(bool IsSuccess, string Message, CompanyReadDTO Data)> AddAsync(CompanyInsertDTO companyInsertDTO);
        Task<(bool IsSuccess, string Message)> UpdateAsync(CompanyUpdateDTO companyUpdateDTO);
        Task<(bool IsSuccess, string Message)> DeleteAsync(CompanyDeleteDTO companyDeleteDTO);
        string GetConnectionStrignDB();
    }
}