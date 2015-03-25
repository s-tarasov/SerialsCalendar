using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

using MySql.Data.MySqlClient;

using Calendar.Identity.MySQL;
using Calendar.Web.Configuration;
using Calendar.Web.Models;

using IdentityRole = Calendar.Identity.MySQL.IdentityRole;

namespace Calendar.Web.App_Start
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped((p) => new MySQLDatabase(
                new MySqlConnection(ConfigurationProvider.Get<string>("Data:DefaultConnection:ConnectionString"))));

            services.AddIdentity<ApplicationUser, IdentityRole>(null)
                .AddMySQLStores();

            services.ConfigureGoogleAuthentication(options =>
            {
                options.ClientId = ConfigurationProvider.Get<string>("ExternalServices:Google:ClientId");
                options.ClientSecret = ConfigurationProvider.Get<string>("ExternalServices:Google:ClientSecret");
            });

            services.AddMvc();
        }
    }
}