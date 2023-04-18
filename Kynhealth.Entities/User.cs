using System;
using System.Collections.Generic;
using System.Text;

namespace Kynhealth.Entities
{
    public class User : ITrackable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public bool IsActive { get; set; }
        
    }
}
