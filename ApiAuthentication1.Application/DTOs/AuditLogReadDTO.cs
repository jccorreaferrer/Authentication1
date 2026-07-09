using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class AuditLogReadDTO
    {
        public int LogId { get; set; }
        public int AdminAppUserId { get; set; }
        public string Action { get; set; }
        public int? TargetAppUserId { get; set; }
        public string Details { get; set; }
        public string IPAddress { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}