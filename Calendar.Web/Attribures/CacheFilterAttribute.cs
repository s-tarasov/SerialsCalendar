using Microsoft.AspNet.Mvc;

namespace Calendar.Web.Filters
{
    public class FeedCacheAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           filterContext.HttpContext.Response.Headers["Cache-Control"] = "max-age=7200, private, must-revalidate";
        }
    }
}
