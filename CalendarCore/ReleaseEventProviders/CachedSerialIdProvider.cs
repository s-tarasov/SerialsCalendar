using System.Threading.Tasks;

namespace SerialsCalendar
{
    public class CachedSerialIdProvider : ISerialIdProvider
    {
        private readonly ISerialIdProvider _provider;
        private readonly IStringCache _cache;

        public CachedSerialIdProvider(ISerialIdProvider provider, IStringCache cache)
        {
            _provider = provider;
            _cache = cache;
        }

        public async Task<string> GetSerialId(string serialAlias)
        {
            return await _cache.GetOrCreateAsync(serialAlias, () => _provider.GetSerialId(serialAlias));
        }
    }
}
