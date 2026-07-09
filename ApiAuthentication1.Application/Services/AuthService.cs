using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly ILicenseRepository _licenseRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(IAppUserRepository appUserRepository, ILicenseRepository licenseRepository, IJwtProvider jwtProvider,  IPasswordHasher passwordHasher)
        {
            _appUserRepository = appUserRepository;
            _licenseRepository = licenseRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> LoginAsync(string user, string password, int appId)
        {
            
            password = _passwordHasher.HashPassword(password);

            var appUser = await _appUserRepository.GetByUserNamePassAndAppIdAsync(user, password, appId);
            if (appUser == null)
            {
                appUser = await _appUserRepository.GetByEmailAndPassAppIdAsync(user, password, appId);
            }

            if (appUser == null)
            {
                return null;
            }

            var license = await _licenseRepository.GetByAppIdAsync(appId);
            bool isPaid = license != null && license.IsPaid;

            return _jwtProvider.GenerateToken(appUser, isPaid);
        }
    }
}