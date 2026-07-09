using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("License")]
    public class License
    {
        [Key]
        public int LicenseId { get; set; }

        [Required]
        [ForeignKey(nameof(App))]
        public int AppId { get; set; }

        [Required]
        [MaxLength(100)]
        public string LicenseName { get; set; }

        public bool IsPaid { get; set; }
        public DateTime? PaidUntil { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual App App { get; set; }

        [ForeignKey(nameof(CreationAppUserId))]
        public virtual AppUser Creator { get; set; }

        [ForeignKey(nameof(UpdateAppUserId))]
        public virtual AppUser Updater { get; set; }
    }
}