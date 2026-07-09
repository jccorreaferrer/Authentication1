namespace ApiAuthentication1.Application.DTOs
{
    public class AppUserUpdateDTO
    {
        public int AppUserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? AppRoleId { get; set; }
        public bool? IsActive { get; set; }
    }
}