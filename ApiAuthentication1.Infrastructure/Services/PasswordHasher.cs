using System;
using System.Security.Cryptography;
using System.Text;
using ApiAuthentication1.Application.Interfaces.Services;

namespace ApiAuthentication1.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var hashedProvided = HashPassword(providedPassword);
            return hashedPassword == hashedProvided;
        }
    }
}