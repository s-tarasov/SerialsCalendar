using System;
using System.Diagnostics;

using Microsoft.Extensions.Configuration;

namespace Calendar.Web.Configuration
{     
    public class ConfigurationAdapter : IConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationAdapter(IConfiguration configuration)
        {
            Debug.Assert(configuration != null);

            _configuration = configuration;
        }

        public T Get<T>(string key, T defaultValue)
        {
            var value = _configuration[key];
            if (String.IsNullOrWhiteSpace(value)) {
                return defaultValue;
            }

            return (T)Convert.ChangeType(value, typeof(T));  
        }
    }
}