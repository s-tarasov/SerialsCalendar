using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Calendar.Builder.ReleaseProviders;

namespace Calendar.Builder
{
    public class ReleaseEventCalendarBuilder
    {
        private readonly ReleaseProviderBase _provider;

        public ReleaseEventCalendarBuilder(ReleaseProviderBase provider)
        {
            Debug.Assert(provider != null);

            _provider = provider;
        }

        public async Task<IEnumerable<ICalendarEvent>> BuildCalendarAsync(IEnumerable<string> serialIds)
        {
            var releaseEvents = await _provider.GetReleasesAsync(serialIds);

            return releaseEvents.Select(e => new ReleaseCalendarEvent(e)).ToArray();
        }
    }
}