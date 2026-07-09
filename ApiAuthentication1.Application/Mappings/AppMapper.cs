using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAuthentication1.Application.Mappings
{
    public static class AppMapper
    {
        public static AppReadDTO ToReadDTO(App app)
        {
            if (app == null) return null;
            return new AppReadDTO
            {
                AppId = app.AppId,
                AppName = app.AppName,
                CompanyId = app.CompanyId,
                IsActive = app.IsActive,
                CreationDate = app.CreationDate,
            };
        }
        public static App toApp(AppInsertDTO appInsertDTO)
        {
            return new App
            {
                AppName = appInsertDTO.AppName,
                CompanyId = appInsertDTO.CompanyId,
                IsActive = true,
                CreationDate = DateTime.Now,
            };
        }
        public static void toAppUpdateDTO(App app, AppUpdateDTO appUpdateDTO)
        {
            if (app == null) return;

            if (appUpdateDTO.AppName != null) app.AppName = appUpdateDTO.AppName;
            if (appUpdateDTO.IsActive.HasValue) app.IsActive = appUpdateDTO.IsActive.Value;
        }
    }
}
