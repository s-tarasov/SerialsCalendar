﻿using System;
using System.Diagnostics.Contracts;

using Microsoft.Framework.Configuration;

namespace Calendar.Web.Configuration
{     
    public class ConfigurationAdapter : IConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationAdapter(IConfiguration configuration)
        {
            Contract.Requires(configuration != null);

            _configuration = configuration;
        }

        public T Get<T>(string key, T defaultValue)
        {
            var value = _configuration.Get(key);
            if (String.IsNullOrWhiteSpace(value)) {
                return defaultValue;
            }

            return (T)Convert.ChangeType(value, typeof(T));  
        }
    }
}