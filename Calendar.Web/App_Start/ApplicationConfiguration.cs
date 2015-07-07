using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;

using Calendar.Web.Configuration;

namespace Calendar.Web.App_Start
{
    public static class ApplicationConfiguration
    {
        public static IConfiguration InitializeAndGetConfiguration(IApplicationEnvironment appEnv) {
            var configuration = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("appSettings.json")
                .AddEnvironmentVariables()
                .Build();

            ConfigurationProvider.SetConfigurationProvider(
                new ConfigurationAdapter(configuration));

            return configuration;
        }
    }
}