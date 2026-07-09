namespace ApiAuthentication1.Application.DTOs
{
    public class EmailSettingsUpdateDTO
    {
        public string ConfigName { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string FromEmail { get; set; }
        public string FromDisplay { get; set; }
        public bool EnableSSL { get; set; }
        public int TimeoutMilliseconds { get; set; }
        public int DefaultPriority { get; set; }
        public bool IsBodyHtml { get; set; }
        public bool IsActive { get; set; }
    }
}