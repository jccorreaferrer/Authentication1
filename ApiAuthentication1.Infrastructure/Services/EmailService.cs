using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ApiAuthentication1.Application.Interfaces.Services;

namespace ApiAuthentication1.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSettingsService _emailSettingsService;

        public EmailService(IEmailSettingsService emailSettingsService)
        {
            _emailSettingsService = emailSettingsService;
        }

        public async Task<(bool IsSuccess, string Message)> SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var settings = await _emailSettingsService.GetActiveSettingsAsync();
                if (settings == null)
                    return (false, "No active email settings found.");

                using var client = new SmtpClient(settings.SmtpHost, settings.SmtpPort)
                {
                    EnableSsl = settings.EnableSSL,
                    Credentials = new NetworkCredential(settings.SmtpUserName, settings.SmtpPassword),
                    Timeout = settings.TimeoutMilliseconds
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(settings.FromEmail, settings.FromDisplay),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = settings.IsBodyHtml
                };
                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);
                return (true, "Email sent successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Email send failed: {ex.Message}");
            }
        }
    }
}