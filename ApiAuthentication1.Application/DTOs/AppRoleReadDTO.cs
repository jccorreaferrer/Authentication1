using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class AppRoleReadDTO
    {
        public int AppRoleId { get; set; }
        public int AppId { get; set; }
        public string AppRoleName { get; set; }
        public string AppRoleDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}