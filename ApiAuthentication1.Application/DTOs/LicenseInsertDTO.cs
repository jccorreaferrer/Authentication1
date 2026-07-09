using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class LicenseInsertDTO
    {
        public int AppId { get; set; }
        public string LicenseName { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidUntil { get; set; }
    }
}