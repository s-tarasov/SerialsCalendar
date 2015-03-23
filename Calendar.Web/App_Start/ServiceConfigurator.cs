using Microsoft.Framework.DependencyInjection;

using MySql.Data.MySqlClient;

using Calendar.Identity.MySQL;
using Calendar.Web.Models;

using IdentityRole = Calendar.Identity.MySQL.IdentityRole;
using Microsoft.AspNet.Builder;

namespace Calendar.Web.App_Start
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped((p) => new MySQLDatabase(
                new MySqlConnection("server=127.0.0.1;database=calendar;uid=calendar;pwd=calendar;")));

            services.AddIdentity<ApplicationUser, IdentityRole>(null)
                .AddMySQLStores();

            services.ConfigureGoogleAuthentication(options =>
            {
                options.ClientId = "977382855444.apps.googleusercontent.com";
                options.ClientSecret = "NafT482F70Vjj_9q1PU4B0pN";
            });

            services.AddMvc();
        }
    }
}