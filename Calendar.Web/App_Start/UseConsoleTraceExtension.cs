using System;

using Microsoft.AspNet.Builder;

namespace Calendar.Web.App_Start
{
    public static class UseConsoleTraceExtension
    {
        public static IApplicationBuilder UseConsoleTrace(this IApplicationBuilder app)
        {
#if DEBUG
            return app.Use(async (context, next) =>
            {
                Console.WriteLine(context.Request.Path);

                try
                {
                    await next();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });
#else
            return app;
#endif
        }
    }
}