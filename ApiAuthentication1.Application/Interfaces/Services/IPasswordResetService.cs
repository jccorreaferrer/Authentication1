using System.Threading.Tasks;
using ApiAuthentication1.Application.DTOs;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface IPasswordResetService
    {
        Task<(bool IsSuccess, string Message)> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO);
        Task<(bool IsSuccess, string Message)> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
    }
}