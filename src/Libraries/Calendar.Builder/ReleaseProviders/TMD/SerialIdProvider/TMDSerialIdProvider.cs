using System.Linq;
using System.Threading.Tasks;

using TMDbLib.Client;

namespace Calendar.Builder.ReleaseProviders.TMD
{
    public class TMDSerialIdProvider : ISerialIdProvider
    {
        private readonly TMDbClient _client;

        public TMDSerialIdProvider(TMDbClient client)
        {
            _client = client;
        }

        public async Task<string> GetSerialId(string serialAlias)
        {
            return (await _client
                .SearchTvShowAsync(serialAlias))
                .Results
                .Select(r => r.Id.ToString())
                .FirstOrDefault();
        }
    }
}