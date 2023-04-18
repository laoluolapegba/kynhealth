using Kynhealth.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kynhealth.Services.Locations
{
    public interface ILocationService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<List<Lga>> GetAllLgas();
        List<State> GetAllStates();
    }
}