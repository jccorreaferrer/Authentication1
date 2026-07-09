using ApiAuthentication1.Domain.Entities;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface IJwtProvider
    {
        string GenerateToken(AppUser appUser, bool isPaid);
    }
}