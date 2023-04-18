using Kynhealth.Data;
using Kynhealth.Entities;
using Kynhealth.Services.Organizations;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kynhealth.Services.Locations
{
    public class LocationService : ILocationService
    {

        private readonly IRepository<Organization> _locationRepo;
        private readonly IRepository<State> _statesRepo;
        private readonly IRepository<Lga> _lgaRepo;
        private readonly IRepository<Country> _countryRepo;

        public LocationService(
            IUnitOfWork unitOfWork,
            ILogger<LocationService> logger)
        {

            _statesRepo = unitOfWork.GetRepository<State>();
            _lgaRepo = unitOfWork.GetRepository<Lga>();
            _countryRepo = unitOfWork.GetRepository<Country>();
        }

        public List<State> GetAllStates()
        {
            return _statesRepo.GetAll().ToList();
        }
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _countryRepo.GetAllAsync();
        }
        public async Task<List<Lga>> GetAllLgas()
        {
            return _lgaRepo.GetAll().ToList();
        }

    }
}
