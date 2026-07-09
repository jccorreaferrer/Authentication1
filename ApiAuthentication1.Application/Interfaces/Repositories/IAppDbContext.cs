using ApiAuthentication1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiAuthentication1.Application.Interfaces.Repositories
{
    public interface IAppDbContext
    {
        DbSet<App> Apps { get; set; }
        DbSet<AppRole> AppRoles { get; set; }
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<License> Licenses { get; set; }
        DbSet<EmailSettings> EmailSettings { get; set; }
        DbSet<JwtSettings> JwtSettings { get; set; }
        DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        DbSet<LoginHistory> LoginHistories { get; set; }
        DbSet<AuditLog> AuditLogs { get; set; }
        Task<int> SaveChangesAsync();
    }
}