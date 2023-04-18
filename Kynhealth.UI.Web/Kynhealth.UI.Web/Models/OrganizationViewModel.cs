using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kynhealth.UI.Web.Models
{
    public class OrganizationViewModel
    {
        

        public OrganizationViewModel()
        {
            Countries = new List<SelectListItem>();
            LocalGovts = new List<SelectListItem>();
            States = new List<SelectListItem>();

        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string? AddressLine1 { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string Telephone { get; set; }
        public int LocalGovtId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string LicenseNo { get; set; }
        public string LocalGovtname { get; set; }
        public string StateName { get; set; }
        public int CountryName { get; set; }
        public IList<SelectListItem> States { get; set; }
        public IList<SelectListItem> Countries { get; set; }
        public IList<SelectListItem> LocalGovts { get; set; }
    }
}
