using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Mappings;

namespace ApiAuthentication1.Application.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AppUserService(IAppUserRepository appUserRepository, IPasswordHasher passwordHasher)
        {
            _appUserRepository = appUserRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<AppUserReadDTO>> GetAllAsync()
        {
            var users = await _appUserRepository.GetAllAsync();
            return users.Select(u => AppUserMapper.ToReadDTO(u));
        }

        public async Task<AppUserReadDTO> GetByIdAsync(int id)
        {
            var user = await _appUserRepository.GetByIdAsync(id);
            return AppUserMapper.ToReadDTO(user);
        }
        public async Task<(bool IsSuccess, string Message, AppUserReadDTO Data)> AddAsync(AppUserInsertDTO appUserInsertDTO)
        {
            var user = AppUserMapper.ToAppUser(appUserInsertDTO);
            user.PasswordHash = _passwordHasher.HashPassword(appUserInsertDTO.Password);
            await _appUserRepository.AddAsync(user);
            return (true, null, AppUserMapper.ToReadDTO(user));

        }

        public async Task<(bool IsSuccess, string Message)> UpdateAsync(AppUserUpdateDTO appUserUpdateDTO)
        {
            var user = await _appUserRepository.GetByIdAsync(appUserUpdateDTO.AppUserId);
            if (user == null) return (false, $"User with ID {appUserUpdateDTO.AppUserId} not found.");

            AppUserMapper.UpdateAppUser(user, appUserUpdateDTO);
            await _appUserRepository.UpdateAsync(user);
            return (true, null);
        }

        public async Task<(bool IsSuccess, string Message)> DeleteAsync(AppUserDeleteDTO appUserDeleteDTO)
        {
            var user = await _appUserRepository.GetByIdAsync(appUserDeleteDTO.AppUserId);
            if (user == null) return (false, $"User with ID {appUserDeleteDTO.AppUserId} not found.");

            await _appUserRepository.DeleteAsync(user);
            return (true, null);
        }

        public async Task<(bool IsSuccess, string Message)> ChangePasswordAsync(AppUserChangePasswordDTO appUserChangePasswordDTO)
        {
            var user = await _appUserRepository.GetByIdAsync(appUserChangePasswordDTO.AppUserId);
            if (user == null)
                return (false, $"User with ID {appUserChangePasswordDTO.AppUserId} not found.");

            if (!_passwordHasher.VerifyPassword(user.PasswordHash, appUserChangePasswordDTO.CurrentPassword))
                return (false, "Current password is incorrect.");

            user.PasswordHash = _passwordHasher.HashPassword(appUserChangePasswordDTO.NewPassword);
            await _appUserRepository.UpdateAsync(user);
            return (true, null);

        }
    }
}