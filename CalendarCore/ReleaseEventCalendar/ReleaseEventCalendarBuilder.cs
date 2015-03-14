using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalendarCore.ReleaseEventCalendar
{
    public class ReleaseEventCalendarBuilder
    {
        private readonly ReleaseEventsProviderBase _provider;

        public ReleaseEventCalendarBuilder(ReleaseEventsProviderBase provider)
        {
            _provider = provider;
        }

        public async Task<IEnumerable<ICalendarEvent>> BuildCalendarAsync(IEnumerable<string> serialIds)
        {
            var releaseEvents = await _provider.GetReleasesAsync(serialIds);

            return releaseEvents.Select(e => new ReleaseCalendarEvent(e)).ToArray();
        }
    }
}