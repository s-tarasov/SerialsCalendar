using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace SerialsCalendar
{
    public class Calendar
    {
        private readonly Task<CalendarService> _service;
        private readonly string _calendarId;

        public Calendar(Task<CalendarService> service, string calendarId)
        {
            if (service == null)
                throw new ArgumentNullException("service");
            if (calendarId == null) throw new ArgumentNullException("calendarId");

            _service = service;
            _calendarId = calendarId;
        }

        public async Task<IEnumerable<CalendarEvent>> GetEventsAsync()
        {
            var request = (await _service).Events
                .List(_calendarId);

            //боремся с кешем
            request.TimeMin = DateTime.Today.AddYears(-3).AddHours(new Random().Next(1000));
            request.MaxResults = 2000;

            return  (await request
                .ExecuteAsync())
                .Items
                .Select(e => new CalendarEvent(e))
                .ToList();
        }

        public async Task AddEventAsync(DateTime date, string summary, string description)
        {
            await (await _service).Events
                .Insert(
                    body: new Event
                    {
                        Summary = summary,
                        Start = new EventDateTime { Date = date.ToString("yyyy-MM-dd") },
                        End = new EventDateTime { Date = date.AddDays(1).ToString("yyyy-MM-dd") },
                        Description = description
                    }, 
                    calendarId: _calendarId)
                .ExecuteAsync();
        }

        public async Task DeleteEventAsync(CalendarEvent @event)
        {
            await ((await _service)).Events.Delete(_calendarId, @event.Id).ExecuteAsync();
        }
    }
}