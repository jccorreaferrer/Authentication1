using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class AppReadDTO
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public int CompanyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}