using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("PasswordResetToken")]
    public class PasswordResetToken
    {
        [Key]
        public int TokenId { get; set; }

        [Required]
        [ForeignKey(nameof(AppUser))]
        public int AppUserId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Token { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public bool Used { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        [InverseProperty(nameof(AppUser.PasswordResetTokens))]
        public virtual AppUser AppUser { get; set; }
    }
}