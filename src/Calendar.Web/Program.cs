using System;
using System.IO;

using Microsoft.AspNetCore.Hosting;

namespace Calendar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://*:80")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
