using ApiAuthentication1.Domain.Entities;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Repositories
{
    public interface IPasswordResetTokenRepository
    {
        Task AddAsync(PasswordResetToken token);
        Task<PasswordResetToken> GetByTokenAsync(string token);
        Task UpdateAsync(PasswordResetToken token);
    }
}