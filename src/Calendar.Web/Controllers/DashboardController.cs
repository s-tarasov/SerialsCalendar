using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Calendar.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Calendar.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public DashboardController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var feedUrl = Url.Link("feeds", new { feedId = userId });

            return base.View(new DashboardModel { FeedUrl = feedUrl });
        }
    }
}
