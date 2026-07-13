using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Repositories
{
    public interface ICompanyAppRepository
    {
        Task AddAsync(CompanyApp companyApp);
        Task<int?> GetCompanyIdByAppIdAsync(int appId);
    }
}