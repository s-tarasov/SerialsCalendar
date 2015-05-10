using Microsoft.Framework.ConfigurationModel;

using Calendar.Web.Configuration;

namespace Calendar.Web.App_Start
{
    public static class ApplicationConfiguration
    {
        public static void Initialize() {
            var configuration = new Microsoft.Framework.ConfigurationModel.Configuration();
            configuration.AddJsonFile("appSettings.json");
            configuration.AddEnvironmentVariables();

            ConfigurationProvider.SetConfigurationProvider(
                new ConfigurationAdapter(configuration));
        }
    }
}