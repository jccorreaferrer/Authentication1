namespace ApiAuthentication1.Application.DTOs
{
    public class AppRoleUpdateDTO
    {
        public int AppRoleId { get; set; }
        public string? AppRoleName { get; set; }
        public string? AppRoleDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}