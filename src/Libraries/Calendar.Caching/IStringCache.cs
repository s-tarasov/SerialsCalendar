using System;
using System.Threading.Tasks;

namespace Calendar.Caching
{
    public interface IStringCache
    {
        Task<string> GetOrCreateAsync(string key, Func<Task<string>> factory);
    }
}
