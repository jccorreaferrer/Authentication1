using System;

namespace ApiAuthentication1.Application.DTOs
{
    public class CompanyReadDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}