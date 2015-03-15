using System;
using System.Diagnostics.Contracts;

namespace Calendar.Web.Configuration
{
    internal static class ConfigurationProvider
    {
        #region StubConfigurationProvider
        private class StubConfigurationProvider : IConfigurationProvider
        {
            public T Get<T>(string key, T defaultValue)
            {
                throw new ApplicationException("Configuration not initialized. Use ConfigurationProvider.SetConfiguration method.");
            }
        }
        #endregion

        private static IConfigurationProvider _configuration = new StubConfigurationProvider();

        public static T Get<T>(string key) {
            return _configuration.Get(key, default(T));
        }

        public static T Get<T>(string key, T defaultValue)
        {
            return _configuration.Get(key, defaultValue);
        }

        public static void SetConfigurationProvider(IConfigurationProvider configuration) {
            Contract.Assert(configuration != null);

            _configuration = configuration;
        }
    }
}