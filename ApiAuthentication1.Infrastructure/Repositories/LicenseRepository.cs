using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApiAuthentication1.Infrastructure.Data.Configurations;

namespace ApiAuthentication1.Infrastructure.Repositories
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly AppDbContext _context;

        public LicenseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<License>> GetAllAsync()
        {
            return await _context.Licenses.ToListAsync();
        }
        public async Task<License> GetByIdAsync(int LicenseId)
        {
            return await _context.Licenses.FindAsync(LicenseId);
        }
        public async Task<License> GetByAppIdAsync(int appId)
        {
            return await _context.Licenses.FirstOrDefaultAsync(l => l.AppId == appId);
        }

        public async Task AddAsync(License license)
        {
            await _context.Licenses.AddAsync(license);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(License license)
        {
            _context.Licenses.Update(license);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(License license)
        {
            _context.Licenses.Remove(license);
            await _context.SaveChangesAsync();
        }
    }
}