using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kynhealth.Data;
using Kynhealth.Entities;
using Microsoft.Extensions.Logging;

namespace Kynhealth.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ILogger<OrganizationService> _logger;
        private readonly IRepository<Organization> _orgRepo;

        public OrganizationService(
            IUnitOfWork unitOfWork,
            ILogger<OrganizationService> logger)
        { 
            _logger = logger;
            _orgRepo = unitOfWork.GetRepository<Organization>();
        }
        public async Task<IEnumerable<Organization>> GetAll()
        {
            return await _orgRepo.GetAllAsync();
        }
        public async Task<Organization> GetByIdAsync(int id)
        {
            return await _orgRepo.GetByIdAsync(id);
        }
        public void CreateOrganization(Organization organization)
        {
            _orgRepo.AddAsync(organization);
        }
        public void UpdateOrganization(Organization organization)
        {
            _orgRepo.UpdateAsync(organization);
        }
        public void DeleteOrganization(int id)
        {
            var org = _orgRepo.GetByIdAsync(id);
            if (org != null)
            {
                _orgRepo.DeleteByIdAsync(id);
            }

        }
    }
}
