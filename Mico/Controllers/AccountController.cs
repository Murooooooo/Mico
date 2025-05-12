using Microsoft.AspNetCore.Mvc;

namespace Mico.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
