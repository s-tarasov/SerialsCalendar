using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerialsCalendar
{
    public class CalendarUpdater
    {
        private readonly Calendar _calendar;

        public CalendarUpdater(Calendar calendar)
        {
            _calendar = calendar;
        }

        public async Task UpdateCalendarAsync(Task<IEnumerable<ReleaseEvent>> loadSerialReleasesTask)
        {
            var calendarEvents = await _calendar.GetEventsAsync();
            var duplicateEvents = calendarEvents.FindDublicates(e => e.Date.ToShortDateString() + e.Summary);
            var releaseEvents = await loadSerialReleasesTask;
            var outdatedEvents = calendarEvents.Where(c => !releaseEvents.Any(r => r.Same(c)));
            var newEvents = releaseEvents.Where(r => !calendarEvents.Any(c => r.Same(c)));

            foreach (var outdatedEvent in outdatedEvents.Union(duplicateEvents).Distinct())
            {
                await _calendar.DeleteEventAsync(outdatedEvent);
            }

            foreach (var newEvent in newEvents)
            {
                await _calendar.AddEventAsync(newEvent.Date, newEvent.Summary);
            }
        }
    }
}