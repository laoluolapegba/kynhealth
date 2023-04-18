
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kynhealth.Entities
{
    [Table("tb_orgs")]
    public class Organization
    {
        //public Oranization()
        //{
        //    this.Users = new HashSet<ApplicationUser>();

        //}
        [Key]
        [Column("Id")]
        public int CompanyId { get; set; }
        
        [Column("company_name")]
        public string CompanyName { get; set; }
        public string? AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string Telephone { get; set; }
        public int LocalGovtId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string LicenseNo { get; set; }
        public virtual ICollection<ApplicationUser> UsersCollection { get; set; }

        public virtual Lga Lga { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}
