using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiAuthentication1.Infrastructure.Repositories
{
    public class PasswordResetTokenRepository : IPasswordResetTokenRepository
    {
        private readonly AppDbContext _context;

        public PasswordResetTokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PasswordResetToken token)
        {
            await _context.PasswordResetTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordResetToken> GetByTokenAsync(string token)
        {
            return await _context.PasswordResetTokens
                .FirstOrDefaultAsync(t => t.Token == token && !t.Used && t.ExpiryDate > DateTime.UtcNow);
        }

        public async Task UpdateAsync(PasswordResetToken token)
        {
            _context.PasswordResetTokens.Update(token);
            await _context.SaveChangesAsync();
        }
    }
}