using System.Threading.Tasks;
using ApiAuthentication1.Domain.Entities;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface IEmailSettingsService
    {
        Task<EmailSettings> GetActiveSettingsAsync();
    }
}