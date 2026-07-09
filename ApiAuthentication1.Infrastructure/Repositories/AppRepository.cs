using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApiAuthentication1.Infrastructure.Data.Configurations;

namespace ApiAuthentication1.Infrastructure.Repositories
{
    public class AppRepository : IAppRepository
    {
        private readonly AppDbContext _context;

        public AppRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<App> GetByIdAsync(int appId)
        {
            return await _context.Apps.FindAsync(appId);
        }
        public async Task<IEnumerable<App>> GetAllAsync()
        {
            return await _context.Apps.ToListAsync();
        }

        public async Task<App> GetWithLicenseAsync(int appId)
        {
            return await _context.Apps
                .Include(a => a.License).FirstOrDefaultAsync(a => a.AppId == appId);
        }

        public async Task AddAsync(App app)
        {
            await _context.Apps.AddAsync(app);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(App app)
        {
            _context.Apps.Update(app);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(App app)
        {
            _context.Apps.Remove(app);
            await _context.SaveChangesAsync();
        }
    }
}