namespace ApiAuthentication1.Application.DTOs
{
    public class ResetPasswordDTO
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}