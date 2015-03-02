using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(IRouteBuilder routes)
        {
            routes.MapRoute("feeds", "feeds/{feedId}", new 
                {
                    controller = "feed",
                    action = "feed"
                });
        }
    }
}

   