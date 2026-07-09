using System;
using System.Threading.Tasks;
using ApiAuthentication1.Application.DTOs;
using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Domain.Entities;

namespace ApiAuthentication1.Application.Services
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IPasswordResetTokenRepository _tokenRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;

        public PasswordResetService(
            IAppUserRepository appUserRepository,
            IPasswordResetTokenRepository tokenRepository,
            IPasswordHasher passwordHasher,
            IEmailService emailService)
        {
            _appUserRepository = appUserRepository;
            _tokenRepository = tokenRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
        }

        public async Task<(bool IsSuccess, string Message)> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user = await _appUserRepository.GetByUserNameAndAppIdAsync(forgotPasswordDTO.EmailOrUsername, forgotPasswordDTO.AppId);
            if (user == null)
            {
                user = await _appUserRepository.GetByEmailAndAppIdAsync(forgotPasswordDTO.EmailOrUsername, forgotPasswordDTO.AppId);
            }

            if (user == null)
                return (false, "User not found.");

            var token = new PasswordResetToken
            {
                AppUserId = user.AppUserId,
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                ExpiryDate = DateTime.UtcNow.AddMinutes(15),
                Used = false,
                IsActive = true,
                CreationDate = DateTime.Now
            };

            await _tokenRepository.AddAsync(token);

            // START CHANGE: Handle the new tuple return from IEmailService
            var (emailSuccess, emailMessage) = await _emailService.SendEmailAsync(user.Email, "Password Reset", $"Reset your password using this token: {token.Token}");
            if (!emailSuccess)
                return (false, $"Email sending failed: {emailMessage}");
            // END CHANGE

            return (true, "Password reset email sent.");
        }

        public async Task<(bool IsSuccess, string Message)> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            var token = await _tokenRepository.GetByTokenAsync(resetPasswordDTO.Token);
            if (token == null)
                return (false, "Invalid or expired token.");

            var user = await _appUserRepository.GetByIdAsync(token.AppUserId);
            if (user == null)
                return (false, "User not found.");

            user.PasswordHash = _passwordHasher.HashPassword(resetPasswordDTO.NewPassword);
            await _appUserRepository.UpdateAsync(user);

            token.Used = true;
            await _tokenRepository.UpdateAsync(token);

            return (true, "Password reset successfully.");
        }
    }
}