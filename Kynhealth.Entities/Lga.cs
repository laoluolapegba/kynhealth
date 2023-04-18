using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kynhealth.Entities
{
    [Table("tb_lga")]
    public class Lga
    {
        
        [Key]
        [Column("Id")]
        public int LgaId   { get; set; }
       
        [Column("lga_name")]
        public string LgaName { get; set; }
        public virtual ICollection<Organization> OranizationCollection { get; set; }
    }
}
