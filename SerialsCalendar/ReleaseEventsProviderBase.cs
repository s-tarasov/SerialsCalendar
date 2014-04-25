using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerialsCalendar
{
    public abstract class ReleaseEventsProviderBase
    {
        protected abstract Task<IEnumerable<ReleaseEvent>> GetSerialReleasesAsync(string serialId);

        public async Task<IEnumerable<ReleaseEvent>> GetReleasesAsync(IEnumerable<string> serialIds)
        {
            var releases = await serialIds
                .Select(GetSerialReleasesAsync)
                .WhenAll();

            return releases.SelectMany(r => r).ToArray();
        }
    }
}