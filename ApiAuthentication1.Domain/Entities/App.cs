using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("App")]
    public class App
    {
        public App()
        {
            AppUsers = new List<AppUser>();
            AppRoles = new List<AppRole>();
        }

        [Key]
        public int AppId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AppName { get; set; }

        [Required]
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<AppRole> AppRoles { get; set; }
        public virtual License License { get; set; }

        // START CHANGE
        [InverseProperty(nameof(AppUser.CreatedApps))]
        [ForeignKey(nameof(CreationAppUserId))]
        public virtual AppUser Creator { get; set; }

        [InverseProperty(nameof(AppUser.UpdatedApps))]
        [ForeignKey(nameof(UpdateAppUserId))]
        public virtual AppUser Updater { get; set; }
        // END CHANGE
    }
}