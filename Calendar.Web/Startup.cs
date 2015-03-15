using System;

using Microsoft.AspNet.Builder;

using Autofac;

using Calendar.Web;
using Calendar.Web.App_Start;
using Calendar.Web.Dependencies;

public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.InitConfiguration();

        app.UseServices(services => {
            ServiceConfigurator.Configure(services);

            var container = ContainerFactory.Create(services);

            return container.Resolve<IServiceProvider>();
        });

        app.UseConsoleTrace();

        app.UseMvc(RouteConfig.RegisterRoutes);
    }
}