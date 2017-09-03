using System;

using Autofac;

using MySql.Data.MySqlClient;

using Calendar.Identity.MySQL;
using Calendar.Web.Configuration;
using Calendar.Web.Dependencies;
using Calendar.Web.Models;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


using IdentityRole = Calendar.Identity.MySQL.IdentityRole;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Calendar.Web.App_Start
{
    public static class ServiceConfigurator
    {
        public static IServiceProvider Configure(IServiceCollection services, IConfiguration configuration)
        {
            // https://console.developers.google.com/project
            services.AddAuthentication().AddGoogle(o =>
            {
                o.ClientId = configuration["ExternalServices:Google:ClientId"];
                o.ClientSecret = configuration["ExternalServices:Google:ClientSecret"];
                o.SaveTokens = true;
                o.Events = new OAuthEvents()
                {
                    OnRemoteFailure = ctx =>
                    {
                        ctx.Response.Redirect("/error?FailureMessage=" + UrlEncoder.Default.Encode(ctx.Failure.Message));
                        ctx.HandleResponse();
                        return Task.FromResult(0);
                    }
                };
                o.ClaimActions.MapJsonSubKey("urn:google:image", "image", "url");
                o.ClaimActions.Remove(ClaimTypes.GivenName);
            });

            services.AddScoped(p => new MySQLDatabase(
                new MySqlConnection(AppConfiguration.Get<string>("Data:DefaultConnection:ConnectionString"))));

            services.AddIdentity<ApplicationUser, IdentityRole>(null)
                .AddMySQLStores();

            services.AddMvc();

            var container = ContainerFactory.Create(services);

            return container.Resolve<IServiceProvider>();
        }
    }
}