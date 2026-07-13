using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAuthentication1.Domain.Entities
{
    [Table("CompanyApp")]
    public class CompanyApp
    {
        [Key]
        public int CompanyAppId { get; set; }

        [Required]
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }

        [Required]
        [ForeignKey(nameof(App))]
        public int AppId { get; set; }

        public bool IsActive { get; set; }

        public int? CreationAppUserId { get; set; }
        public DateTime CreationDate { get; set; }

        public int? UpdateAppUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Company Company { get; set; }

        public virtual App App { get; set; }
    }
}