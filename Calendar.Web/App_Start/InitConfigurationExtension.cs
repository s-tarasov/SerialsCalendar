using Microsoft.AspNet.Builder;
using Microsoft.Framework.ConfigurationModel;

using Calendar.Web.Configuration;

namespace Calendar.Web.App_Start
{
    public static class InitConfigurationExtension
    {
        public static void InitConfiguration(this IApplicationBuilder app) {
            var configuration = new Microsoft.Framework.ConfigurationModel.Configuration();
            configuration.AddJsonFile("appSettings.json");
            configuration.AddEnvironmentVariables();

            ConfigurationProvider.SetConfigurationProvider(
                new ConfigurationAdapter(configuration));
        }
    }
}