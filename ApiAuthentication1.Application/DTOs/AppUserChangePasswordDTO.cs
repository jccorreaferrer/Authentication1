namespace ApiAuthentication1.Application.DTOs
{
    public class AppUserChangePasswordDTO
    {
        public int AppUserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}