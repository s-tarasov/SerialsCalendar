using System.Security.Claims;

using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

using Calendar.Web.Models;

namespace Calendar.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            //TODO Url.Link coming) 
            var feedUrl = Url.RouteUrl("feeds", new { feedId = User.GetUserId() }, 
                Request.Scheme, Request.Host.ToUriComponent());

            return base.View(new DashboardModel { FeedUrl = feedUrl });
        }
    }
}
