using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("EmailSettings")]
    public class EmailSettings
    {
        [Key]
        public int EmailSettingsId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ConfigName { get; set; }

        [Required]
        [MaxLength(200)]
        public string SmtpHost { get; set; }

        [Required]
        public int SmtpPort { get; set; }

        [MaxLength(200)]
        public string SmtpUserName { get; set; }

        [MaxLength(200)]
        public string SmtpPassword { get; set; }

        [Required]
        [MaxLength(200)]
        public string FromEmail { get; set; }

        [MaxLength(100)]
        public string FromDisplay { get; set; }

        public bool EnableSSL { get; set; }
        public int TimeoutMilliseconds { get; set; }
        public int DefaultPriority { get; set; }
        public bool IsBodyHtml { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey(nameof(CreationAppUserId))]
        public virtual AppUser Creator { get; set; }

        [ForeignKey(nameof(UpdateAppUserId))]
        public virtual AppUser Updater { get; set; }
    }
}