using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("Company")]
    public class Company
    {
        public Company()
        {
            CompanyApps = new List<CompanyApp>();
        }

        [Key]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<CompanyApp> CompanyApps { get; set; }

        [ForeignKey(nameof(CreationAppUserId))]
        public virtual AppUser Creator { get; set; }

        [ForeignKey(nameof(UpdateAppUserId))]
        public virtual AppUser Updater { get; set; }
    }
}