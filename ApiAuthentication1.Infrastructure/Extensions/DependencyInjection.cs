using ApiAuthentication1.Application.Interfaces.Repositories;
using ApiAuthentication1.Application.Interfaces.Services;
using ApiAuthentication1.Application.Services;
using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Infrastructure.Data.Configurations;
using ApiAuthentication1.Infrastructure.Repositories;
using ApiAuthentication1.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAuthentication1.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAppDbContext>(provider =>
                provider.GetRequiredService<AppDbContext>());

            services.AddScoped<IAppRepository, AppRepository>();
            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();

            services.AddScoped<IAppService, AppService>();
            services.AddScoped<IAppRoleService, AppRoleService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ILicenseService, LicenseService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtSettingsService, JwtSettingsService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();
            services.AddScoped<IPasswordResetService, PasswordResetService>();
            services.AddScoped<IEmailSettingsService, EmailSettingsService>();

            return services;
        }
    }
}