namespace ApiAuthentication1.Application.DTOs
{
    public class JwtSettingsInsertDTO
    {
        public string ConfigName { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}