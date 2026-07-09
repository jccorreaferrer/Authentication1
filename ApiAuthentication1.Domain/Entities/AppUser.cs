using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("AppUser")]
    public class AppUser
    {
        public AppUser()
        {
            PasswordResetTokens = new List<PasswordResetToken>();
            LoginHistories = new List<LoginHistory>();
            AdminAuditLogs = new List<AuditLog>();
            TargetAuditLogs = new List<AuditLog>();
            CreatedApps = new List<App>();
            UpdatedApps = new List<App>();
        }

        [Key]
        public int AppUserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [ForeignKey(nameof(App))]
        public int AppId { get; set; }

        [Required]
        [ForeignKey(nameof(AppRole))]
        public int AppRoleId { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        [InverseProperty(nameof(App.AppUsers))]
        public virtual App App { get; set; }

        [InverseProperty(nameof(AppRole.AppUsers))]
        public virtual AppRole AppRole { get; set; }

        [ForeignKey(nameof(CreationAppUserId))]
        public virtual AppUser Creator { get; set; }

        [ForeignKey(nameof(UpdateAppUserId))]
        public virtual AppUser Updater { get; set; }

        // START CHANGE
        [InverseProperty(nameof(App.Creator))]
        public virtual ICollection<App> CreatedApps { get; set; }

        [InverseProperty(nameof(App.Updater))]
        public virtual ICollection<App> UpdatedApps { get; set; }

        [InverseProperty(nameof(LoginHistory.AppUser))]
        public virtual ICollection<LoginHistory> LoginHistories { get; set; }

        [InverseProperty(nameof(AuditLog.AdminAppUser))]
        public virtual ICollection<AuditLog> AdminAuditLogs { get; set; }

        [InverseProperty(nameof(AuditLog.TargetAppUser))]
        public virtual ICollection<AuditLog> TargetAuditLogs { get; set; }

        [InverseProperty(nameof(PasswordResetToken.AppUser))]
        public virtual ICollection<PasswordResetToken> PasswordResetTokens { get; set; }
        // END CHANGE
    }
}