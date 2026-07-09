using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("JwtSettings")]
    public class JwtSettings
    {
        [Key]
        public int JwtSettingsId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ConfigName { get; set; }

        [Required]
        public string SecretKey { get; set; }

        [Required]
        [MaxLength(200)]
        public string Issuer { get; set; }

        [Required]
        [MaxLength(200)]
        public string Audience { get; set; }

        [Required]
        public int ExpiryMinutes { get; set; }

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