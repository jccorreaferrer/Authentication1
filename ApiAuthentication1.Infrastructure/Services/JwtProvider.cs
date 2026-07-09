using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ApiAuthentication1.Infrastructure.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IJwtSettingsService _jwtSettingsService;

        public JwtProvider(IJwtSettingsService jwtSettingsService)
        {
            _jwtSettingsService = jwtSettingsService;
        }

        public string GenerateToken(AppUser appUser, bool isPaid)
        {
            var settings = _jwtSettingsService.GetSingleAsync().GetAwaiter().GetResult();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, appUser.AppUserId.ToString()),
                new Claim("AppUserId", appUser.AppUserId.ToString()),
                new Claim("AppId", appUser.AppId.ToString()),
                new Claim("AppRoleId", appUser.AppRoleId.ToString()),
                new Claim("IsPaid", isPaid.ToString().ToLower()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: settings.Issuer,
                audience: settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(settings.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}