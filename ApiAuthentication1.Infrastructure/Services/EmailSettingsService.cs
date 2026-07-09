using System.Threading.Tasks;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ApiAuthentication1.Infrastructure.Services
{
    public class EmailSettingsService : IEmailSettingsService
    {
        private readonly AppDbContext _context;

        public EmailSettingsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmailSettings> GetActiveSettingsAsync()
        {
            return await _context.EmailSettings.FirstOrDefaultAsync(e => e.IsActive);
        }
    }
}