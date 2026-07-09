namespace ApiAuthentication1.Application.DTOs
{
    public class AppUpdateDTO
    {
        public int AppId { get; set; }
        public string? AppName { get; set; }
        public bool? IsActive { get; set; }
    }
}   