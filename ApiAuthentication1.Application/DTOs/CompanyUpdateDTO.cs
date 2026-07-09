namespace ApiAuthentication1.Application.DTOs
{
    public class CompanyUpdateDTO
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public bool? IsActive { get; set; }
    }
}