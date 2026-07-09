using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class JwtSettingsReadDTO
    {
        public int JwtSettingsId { get; set; }
        public string ConfigName { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}