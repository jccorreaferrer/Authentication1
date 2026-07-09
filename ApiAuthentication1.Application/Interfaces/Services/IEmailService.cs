using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    // START CHANGE: Changed return type from Task to Task<(bool IsSuccess, string Message)>
    public interface IEmailService
    {
        Task<(bool IsSuccess, string Message)> SendEmailAsync(string to, string subject, string body);
    }
    // END CHANGE
}