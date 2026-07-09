using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("LoginHistory")]
    public class LoginHistory
    {
        [Key]
        public int HistoryId { get; set; }

        [Required]
        [ForeignKey(nameof(AppUser))]
        public int AppUserId { get; set; }

        [Required]
        public bool IsSuccess { get; set; }

        [MaxLength(50)]
        public string IPAddress { get; set; }

        [MaxLength(200)]
        public string UserAgent { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        [InverseProperty(nameof(AppUser.LoginHistories))]
        public virtual AppUser AppUser { get; set; }

        // START CHANGE: Removed Creator and Updater to avoid ambiguity
        // END CHANGE
    }
}