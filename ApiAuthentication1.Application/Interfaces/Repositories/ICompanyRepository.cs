using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ApiAuthentication1.Application.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(int companyId);
        Task<IEnumerable<Company>> GetAllAsync();
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(Company company);
        string GetConnectionStrignDB();
    }
}