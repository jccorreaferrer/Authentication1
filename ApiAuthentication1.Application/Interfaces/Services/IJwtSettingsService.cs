using ApiAuthentication1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAuthentication1.Application.Interfaces.Services
{
    public interface IJwtSettingsService
    {
        Task<JwtSettings> GetSingleAsync();
    }
}
