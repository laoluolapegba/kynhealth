using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Net;

namespace Kynhealth.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? OrganizationCompanyId { get; set; }
        public string? AddressLine1 { get; set; } = string.Empty;
        public string Gender { get; set; }
        
        public int? AgeGroup { get; set; }
        public int? PreferredChannel { get; set; }
        public byte[] ProfilePicture { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
