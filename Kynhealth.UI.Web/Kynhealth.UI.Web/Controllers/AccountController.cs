using Microsoft.AspNetCore.Mvc;

namespace Kynhealth.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
