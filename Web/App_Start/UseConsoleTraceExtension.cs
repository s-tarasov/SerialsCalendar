using System;
using System.Diagnostics;

using Microsoft.AspNet.Builder;

namespace Web.App_Start
{
    public static class UseConsoleTraceExtension
    {
        [Conditional("DEBUG")]
        public static void UseConsoleTrace(this IApplicationBuilder app) {
            app.Use(async (context, next) =>
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
        }
    }
}