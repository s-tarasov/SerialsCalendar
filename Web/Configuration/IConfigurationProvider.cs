using System;
using System.Diagnostics.Contracts;

namespace Web.Configuration
{
    [ContractClass(typeof(ConfigurationProviderContracts))]
    public interface IConfigurationProvider
    {
        T Get<T>(string key, T defaultValue);
    }

    [ContractClassFor(typeof(IConfigurationProvider))]
    internal abstract class ConfigurationProviderContracts : IConfigurationProvider
    {
        public T Get<T>(string key, T defaultValue)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(key));

            throw new NotImplementedException();
        }
    }
}