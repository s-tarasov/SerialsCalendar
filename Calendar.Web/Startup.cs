using System;
using System.IO;

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;

using Calendar.Web;
using Calendar.Web.App_Start;

public class Startup
{
    private IConfiguration _configuration;

    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
        _configuration = ApplicationConfiguration.InitializeAndGetConfiguration(appEnv);
    }

    public IServiceProvider ConfigureServices(IServiceCollection services) {
        return ServiceConfigurator.Configure(services, _configuration);
    }

    public void Configure(IApplicationBuilder app)
    {
        app
            .UseApplicationInsightsRequestTelemetry()
            .UseConsoleTrace()
            .UseStaticFiles()
            .UseIdentity()
            .UseGoogleAuthentication()
            .UseMvc(RouteConfig.RegisterRoutes)
            .UseApplicationInsightsExceptionTelemetry();

        //TODO remove fix after update to rc1
        var temp = Environment.GetEnvironmentVariable("ASPNET_TEMP");
        if (string.IsNullOrWhiteSpace(temp)) {
            Environment.SetEnvironmentVariable("ASPNET_TEMP", Path.GetTempPath());
        }
    }
}