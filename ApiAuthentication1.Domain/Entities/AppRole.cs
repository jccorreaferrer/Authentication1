using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("AppRole")]
    public class AppRole
    {
        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }

        [Key]
        public int AppRoleId { get; set; }

        [Required]
        [ForeignKey(nameof(App))]
        public int AppId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AppRoleName { get; set; }

        [MaxLength(200)]
        public string AppRoleDescription { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual App App { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }


    }
}