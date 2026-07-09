using System.Threading.Tasks;
using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Interfaces.Repositories;
using System.Linq;

namespace ApiAuthentication1.Application.Services
{
    public class JwtSettingsService : IJwtSettingsService
    {
        private readonly IAppDbContext _context;

        public JwtSettingsService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<JwtSettings> GetSingleAsync()
        {
            // For MVP, assume only one row exists.
            return await Task.FromResult(new JwtSettings
            {
                JwtSettingsId = 1,
                ConfigName = "Default",
                SecretKey = "YourSuperSecretKeyThatIsAtLeast32CharactersLong!",
                Issuer = "ApiAuthentication1",
                Audience = "ApiAuthentication1",
                ExpiryMinutes = 240
            });
        }
    }
}