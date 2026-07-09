using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Domain.Entities;

namespace ApiAuthentication1.Application.Mappings
{
    public static class AppUserMapper
    {
        public static AppUserReadDTO ToReadDTO(AppUser user)
        {
            if (user == null) return null;

            return new AppUserReadDTO
            {
                AppUserId = user.AppUserId,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AppId = user.AppId,
                AppRoleId = user.AppRoleId,
                IsActive = user.IsActive,
                CreationDate = user.CreationDate
            };
        }

        public static AppUser ToAppUser(AppUserInsertDTO appUserInsertDTO)
        {
            return new AppUser
            {
                UserName = appUserInsertDTO.UserName,
                Email = appUserInsertDTO.Email,
                PasswordHash = appUserInsertDTO.Password, // Placeholder: will be hashed later
                FirstName = appUserInsertDTO.FirstName,
                LastName = appUserInsertDTO.LastName,
                AppId = appUserInsertDTO.AppId,
                AppRoleId = appUserInsertDTO.AppRoleId,
                IsActive = true,
                CreationDate = System.DateTime.Now
            };
        }

        public static void UpdateAppUser(AppUser appUser, AppUserUpdateDTO appUserUpdateDTO)
        {
            if (appUser == null) return;
            if (appUserUpdateDTO.FirstName != null)
                appUser.FirstName = appUserUpdateDTO.FirstName;
            if (appUserUpdateDTO.LastName != null)
                appUser.LastName = appUserUpdateDTO.LastName;
            if (appUserUpdateDTO.AppRoleId.HasValue)
                appUser.AppRoleId = appUserUpdateDTO.AppRoleId.Value;
            if (appUserUpdateDTO.IsActive.HasValue)
                appUser.IsActive = appUserUpdateDTO.IsActive.Value;
        }
    }
}