using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class LicenseReadDTO
    {
        public int LicenseId { get; set; }
        public int AppId { get; set; }
        public string LicenseName { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidUntil { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}