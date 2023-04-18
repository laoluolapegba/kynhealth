using Kynhealth.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kynhealth.Services.Organizations
{
    public interface IOrganizationService
    {
        void CreateOrganization(Organization organization);
        void DeleteOrganization(int id);
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization> GetByIdAsync(int id);
        void UpdateOrganization(Organization organization);
    }
}