
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kynhealth.Entities
{
    [Table("tb_country")]
    public class Country
    {
        
        [Key]
        [Column("Id")]
        public int CountryId { get; set; }
        [Column("iso_code")]
        public string CountryISOCode { get; set; }
        [Column("country_name")]
        public string CountryName { get; set; }
        public virtual ICollection<Organization> OranizationCollection { get; set; }
    }
}
