namespace Calendar.Web.Configuration
{
    public interface IConfigurationProvider
    {
        T Get<T>(string key, T defaultValue);
    }
}