using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Calendar.Web;
using Calendar.Web.App_Start;

public class Startup
{
    private IConfiguration _configuration;

    public Startup(IHostingEnvironment env)
    {
        _configuration = ApplicationConfiguration.InitializeAndGetConfiguration(env);
    }

    public IServiceProvider ConfigureServices(IServiceCollection services) {
        return ServiceConfigurator.Configure(services, _configuration);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(_configuration.GetSection("Logging"));
        loggerFactory.AddDebug();

        app
            .UseStaticFiles()
            .UseAuthentication()
            .UseDeveloperExceptionPage()
            .UseMvc(RouteConfig.RegisterRoutes);
    }
}