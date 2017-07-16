using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

using Calendar.Web.Configuration;

using AppConfiguration = Calendar.Web.Configuration.AppConfiguration;

namespace Calendar.Web.App_Start
{
    public static class ApplicationConfiguration
    {
        public static IConfiguration InitializeAndGetConfiguration(IHostingEnvironment env) {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            AppConfiguration.SetConfigurationProvider(
                new ConfigurationAdapter(configuration));

            return configuration;
        }
    }
}