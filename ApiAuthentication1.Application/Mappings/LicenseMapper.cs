using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAuthentication1.Application.Mappings
{
    public static class LicenseMapper
    {
        public static LicenseReadDTO ToReadDTO(License license)
        {
            if (license == null) return null;
            return new LicenseReadDTO
            {
                LicenseId = license.LicenseId,
                AppId = license.AppId,
                LicenseName = license.LicenseName,
                IsPaid = license.IsPaid,
                PaidUntil = license.PaidUntil,
                IsActive = license.IsActive,
                CreationDate = license.CreationDate,
            };
        }

        public static License tolicense(LicenseInsertDTO licenseInsertDTO)
        {
            return new License
            {
                AppId = licenseInsertDTO.AppId,
                LicenseName = licenseInsertDTO.LicenseName,
                IsPaid = licenseInsertDTO.IsPaid,
                PaidUntil = licenseInsertDTO.PaidUntil,
            };
        }
        public static void toLicenseUpdateDTO(License license, LicenseUpdateDTO licenseUpdateDTO)
        {
            if (license == null) return;

            if (licenseUpdateDTO.LicenseId != null) license.LicenseId = licenseUpdateDTO.LicenseId;
            if (licenseUpdateDTO.LicenseName != null) license.LicenseName = licenseUpdateDTO.LicenseName;
            if (licenseUpdateDTO.IsPaid.HasValue) license.IsPaid = licenseUpdateDTO.IsPaid.Value;
            if (licenseUpdateDTO.PaidUntil.HasValue) license.PaidUntil = licenseUpdateDTO.PaidUntil.Value;
            if (licenseUpdateDTO.IsActive.HasValue) license.IsActive = licenseUpdateDTO.IsActive.Value;
        }


    }
}
