using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class AppUserReadDTO
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppId { get; set; }
        public int AppRoleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}