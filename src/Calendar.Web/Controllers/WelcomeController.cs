using Microsoft.AspNetCore.Mvc;

namespace Calendar.Web.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }
    }
}
