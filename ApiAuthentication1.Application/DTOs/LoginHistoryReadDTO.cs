using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class LoginHistoryReadDTO
    {
        public int HistoryId { get; set; }
        public int AppUserId { get; set; }
        public bool IsSuccess { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}