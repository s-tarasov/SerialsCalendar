using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Calendar.Builder;

using Ical.Net.Serialization;
using Ical.Net.DataTypes;

using Microsoft.AspNetCore.Mvc;
using Ical.Net.Serialization.iCalendar.Serializers;

namespace Calendar.Web.ViewResults
{
    public class CalendarResult : IActionResult
    {
        private readonly IEnumerable<ICalendarEvent> _events;
        private readonly string _fileName;

        public CalendarResult(string fileName, IEnumerable<ICalendarEvent> events)
        {
            _events = events;
            _fileName = fileName;
        }

        public async Task ExecuteResultAsync(ActionContext context) {
            var calendar = CreateCalendar();
            var bytes = Serialize(calendar);
            var result = new FileContentResult(bytes, "text/calendar");
            result.FileDownloadName = _fileName;

            await result.ExecuteResultAsync(context);
        }

        private Ical.Net.Calendar CreateCalendar()
        {
            var iCal = new Ical.Net.Calendar();
            foreach (var calendarEvent in _events)
            {
                var evt = new Ical.Net.CalendarEvent();
                evt.Start = new CalDateTime(calendarEvent.Start);
                evt.End = new CalDateTime(calendarEvent.End);
                evt.Description = calendarEvent.Description;
                evt.Location = calendarEvent.Location;
                evt.Summary = calendarEvent.Summary;
                iCal.Events.Add(evt);
            }

            return iCal;
        }

        private static byte[] Serialize(Ical.Net.Calendar iCal)
        {
            var serializer = new CalendarSerializer(new SerializationContext());
            var output = serializer.SerializeToString(iCal);
            return Encoding.UTF8.GetBytes(output);
        }
    }
}