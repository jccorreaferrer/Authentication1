using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("AuditLog")]
    public class AuditLog
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        [ForeignKey(nameof(AdminAppUser))]
        public int AdminAppUserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Action { get; set; }

        [ForeignKey(nameof(TargetAppUser))]
        public int? TargetAppUserId { get; set; }

        public string Details { get; set; }

        [MaxLength(50)]
        public string IPAddress { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        // START CHANGE
        [InverseProperty(nameof(AppUser.AdminAuditLogs))]
        public virtual AppUser AdminAppUser { get; set; }

        [InverseProperty(nameof(AppUser.TargetAuditLogs))]
        public virtual AppUser TargetAppUser { get; set; }
        // END CHANGE
    }
}