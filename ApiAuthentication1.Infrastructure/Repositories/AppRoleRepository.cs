using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiAuthentication1.Infrastructure.Data.Configurations;

namespace ApiAuthentication1.Infrastructure.Repositories
{
    public class AppRoleRepository : IAppRoleRepository
    {
        private readonly AppDbContext _context;

        public AppRoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppRole> GetByIdAsync(int appRoleId)
        {
            return await _context.AppRoles.FindAsync(appRoleId);
        }

        public async Task<IEnumerable<AppRole>> GetByAppIdAsync(int appId)
        {
            return await _context.AppRoles
                .Where(r => r.AppId == appId)
                .ToListAsync();
        }

        public async Task AddAsync(AppRole appRole)
        {
            await _context.AppRoles.AddAsync(appRole);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppRole appRole)
        {
            _context.AppRoles.Update(appRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AppRole appRole)
        {
            _context.AppRoles.Remove(appRole);
            await _context.SaveChangesAsync();
        }
    }
}