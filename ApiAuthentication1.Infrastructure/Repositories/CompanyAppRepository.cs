using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Infrastructure.Data.Configurations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiAuthentication1.Infrastructure.Repositories
{
    public class CompanyAppRepository : ICompanyAppRepository
    {
        private readonly AppDbContext _context;

        public CompanyAppRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CompanyApp companyApp)
        {
            await _context.CompanyApps.AddAsync(companyApp);
            await _context.SaveChangesAsync();
        }
        public async Task<int?> GetCompanyIdByAppIdAsync(int appId)
        {
            var companyApp = await _context.CompanyApps
                .FirstOrDefaultAsync(x => x.AppId == appId);

            return companyApp?.CompanyId;
        }
    }
}