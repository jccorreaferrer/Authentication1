using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAuthentication1.Application.Mappings
{
    public static class AppRoleMapper
    {
        public static AppRoleReadDTO ToReadDTO(AppRole appRole)
        {
            if (appRole == null) return null;
            return new AppRoleReadDTO
            {
                AppRoleId = appRole.AppRoleId,
                AppId = appRole.AppId,
                AppRoleName = appRole.AppRoleName,
                AppRoleDescription = appRole.AppRoleDescription,
                IsActive = appRole.IsActive,
                CreationDate = appRole.CreationDate,
            };
        }

        public static AppRole toAppRole(AppRoleInsertDTO appRoleInsertDTO)
        {
            return new AppRole
            {
                AppId = appRoleInsertDTO.AppId,
                AppRoleName = appRoleInsertDTO.AppRoleName,
                AppRoleDescription = appRoleInsertDTO.AppRoleDescription,
                IsActive = true,
                CreationDate = DateTime.Now,
            };
        }
        public static void toAppRoleUpdateDTO(AppRole appRole, AppRoleUpdateDTO appRoleUpdateDTO)
        {
            if (appRole == null) return;

            if (appRoleUpdateDTO.AppRoleName != null) appRole.AppRoleName = appRoleUpdateDTO.AppRoleName;
            if (appRoleUpdateDTO.AppRoleDescription != null) appRole.AppRoleDescription = appRoleUpdateDTO.AppRoleDescription;
            if (appRoleUpdateDTO.IsActive.HasValue) appRole.IsActive = appRoleUpdateDTO.IsActive.Value;
        }

    }
}
