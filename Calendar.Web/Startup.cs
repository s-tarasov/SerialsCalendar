using System;
using System.IO;

using Microsoft.AspNet.Builder;

using Microsoft.Framework.DependencyInjection;

using Autofac;

using Calendar.Web;
using Calendar.Web.App_Start;
using Calendar.Web.Dependencies;

public class Startup
{
    public IServiceProvider ConfigureServices(IServiceCollection services) {
        ApplicationConfiguration.Initialize();
        ServiceConfigurator.Configure(services);

        var container = ContainerFactory.Create(services);

        return container.Resolve<IServiceProvider>();
    }

    public void Configure(IApplicationBuilder app)
    {
        app
            .UseConsoleTrace()
            .UseStaticFiles()
            .UseIdentity()
            .UseGoogleAuthentication()
            .UseMvc(RouteConfig.RegisterRoutes);

        //TODO remove fix after update to rc1
        var temp = Environment.GetEnvironmentVariable("ASPNET_TEMP");
        if (string.IsNullOrWhiteSpace(temp)) {
            Environment.SetEnvironmentVariable("ASPNET_TEMP", Path.GetTempPath());
        }
    }
}