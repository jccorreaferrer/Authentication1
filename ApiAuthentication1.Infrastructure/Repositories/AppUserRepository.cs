using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApiAuthentication1.Infrastructure.Data.Configurations;

namespace ApiAuthentication1.Infrastructure.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;

        public AppUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByUserNameAndAppIdAsync(string userName, int appId)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.UserName == userName && u.AppId == appId);
        }

        public async Task<AppUser> GetByEmailAndAppIdAsync(string email, int appId)
        {
            return await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == email && u.AppId == appId);
        }

        public async Task<AppUser> GetByIdAsync(int appUserId)
        {
            return await _context.AppUsers.FindAsync(appUserId);
        }
        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.AppUsers.ToListAsync();
        }
        public async Task AddAsync(AppUser appUser)
        {
            await _context.AppUsers.AddAsync(appUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppUser appUser)
        {
            _context.AppUsers.Update(appUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AppUser appUser)
        {
            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();
        }
    }
}