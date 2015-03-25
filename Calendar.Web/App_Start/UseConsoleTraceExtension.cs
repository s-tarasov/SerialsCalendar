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
                try
                {
                    await next();
                        if (context.Response.StatusCode == 404) {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        Console.WriteLine(context.Response.StatusCode + ":" + context.Request.Path);
                        Console.ResetColor();
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