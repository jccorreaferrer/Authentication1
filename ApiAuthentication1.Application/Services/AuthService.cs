using System.Threading.Tasks;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Domain.Entities;

namespace ApiAuthentication1.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(IAppUserRepository appUserRepository, ILicenseRepository licenseRepository, IJwtProvider jwtProvider)
        {
            _appUserRepository = appUserRepository;
            _licenseRepository = licenseRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> LoginAsync(string user, string password, int appId)
        {
            var appUser = await _appUserRepository.GetByUserNameAndAppIdAsync(user, appId);
            if (appUser == null)
            {
                appUser = await _appUserRepository.GetByEmailAndAppIdAsync(user, appId);
            }

            if (appUser == null)
            {
                return null;
            }

            // For MVP, password is not validated. Replace with proper hashing later.
            var license = await _licenseRepository.GetByAppIdAsync(appId);
            bool isPaid = license != null && license.IsPaid;

            return _jwtProvider.GenerateToken(appUser, isPaid);
        }
    }
}