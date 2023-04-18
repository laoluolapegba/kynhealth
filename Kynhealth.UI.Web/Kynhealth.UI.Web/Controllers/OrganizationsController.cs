using AutoMapper;
using Kynhealth.Entities;
using Kynhealth.Services.Locations;
using Kynhealth.Services.Organizations;
using Kynhealth.UI.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Kynhealth.UI.Web.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService _orgService;
        private readonly ILogger<OrganizationsController> _logger;
        private readonly IMapper _mapper;
        private readonly ILocationService _locationService;

        public OrganizationsController(
            IOrganizationService organizationService,
            ILogger<OrganizationsController> logger,
            ILocationService locationService,
            IMapper mapper
            ) { 
        _orgService = organizationService;
        _logger = logger;
        _mapper = mapper;
            _locationService = locationService;

        }

        public async Task<IActionResult> Index()
        {
            var orgs = await _orgService.GetAll();

            var dataView = _mapper.Map<IEnumerable<Organization>, IEnumerable<OrganizationViewModel>>(orgs);
            
            return View(dataView);
        }
        public async Task<IActionResult> Create()
        {
            var model = new OrganizationViewModel();
            //PrepareModelAsync(model);
            return View(model);
        }
        public IActionResult Create_()
        {
            var model = new OrganizationViewModel();
            PrepareModelAsync(model);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrganizationViewModel model)
        {
            return View(model);
        }
        public async Task PrepareModelAsync(OrganizationViewModel model)
        {
            //locations
            var allstates = _locationService.GetAllStates();
            var organizations = await _locationService.GetAllCountries();
            
            model.States.Add(new SelectListItem { Text = "--Select--", Value = "0" });
            foreach (var loc in allstates)
                model.States.Add(new SelectListItem { Text = loc.StateName, Value = loc.StateId.ToString() });

            model.Countries.Add(new SelectListItem { Text = "--Select--", Value = "0" });
            foreach (var loc in organizations)
                model.States.Add(new SelectListItem { Text = loc.CountryName, Value = loc.CountryId.ToString() });


        }
    }
}
