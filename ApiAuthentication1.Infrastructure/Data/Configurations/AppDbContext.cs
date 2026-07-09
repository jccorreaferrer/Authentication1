using ApiAuthentication1.Domain.Entities;
using ApiAuthentication1.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiAuthentication1.Infrastructure.Data.Configurations
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<App> Apps { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<EmailSettings> EmailSettings { get; set; }
        public DbSet<JwtSettings> JwtSettings { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<LoginHistory> LoginHistories { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        async Task<int> IAppDbContext.SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}