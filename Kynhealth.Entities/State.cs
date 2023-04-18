
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kynhealth.Entities
{
    [Table("tb_states")]
    public class State
    {
        
        [Key]
        [Column("Id")]
        public int StateId { get; set; }
        
        [Column("state_name")]
        public string StateName { get; set; }
        public virtual ICollection<Organization> OranizationCollection { get; set; }
    }
}
