using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class PasswordResetTokenReadDTO
    {
        public int TokenId { get; set; }
        public int AppUserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Used { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}