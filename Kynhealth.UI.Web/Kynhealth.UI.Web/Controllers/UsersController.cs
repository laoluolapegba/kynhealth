using Kynhealth.Entities;
using Kynhealth.UI.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kynhealth.UI.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModel = new List<UsersViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UsersViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Organization = user.Organization.CompanyName.ToString();
                //thisViewModel.Roles = await GetUserRoles(user);
                userViewModel.Add(thisViewModel);
            }
            return View(userViewModel);
            return View();
        }
    }
}
