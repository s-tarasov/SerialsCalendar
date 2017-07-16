using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Calendar.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(IRouteBuilder routes)
        {
            routes.MapRoute("welcome", "", new
            {
                controller = "welcome",
                action = "Index"
            });

            routes.MapRoute("dashboard", "dashboard", new
            {
                controller = "dashboard",
                action = "Index"
            });

            routes.MapRoute("feeds", "feeds/{feedId}", new 
                {
                    controller = "feed",
                    action = "feed"
                });

            routes.MapRoute(
               name: "default",
               template: "{controller}/{action}/{id?}",
               defaults: new { controller = "Home", action = "Index" });
        }
    }
}

   