using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;

using DDay.iCal;
using DDay.iCal.Serialization;
using DDay.iCal.Serialization.iCalendar;

using SerialsCalendar;

namespace Web.ViewResults
{
    public class CalendarResult : FileResult
    {
        private readonly IEnumerable<ICalendarEvent> _events;

        public CalendarResult(string fileName, IEnumerable<ICalendarEvent> events)
            : base("text/calendar")
        {
            _events = events;
            FileDownloadName = fileName;
        }

        protected override async Task WriteFileAsync(HttpResponse response, CancellationToken cancellation)
        {
            var iCal = new iCalendar();
            foreach (var calendarEvent in _events)
            {
                var evt = iCal.Create<Event>();
                evt.Start = new iCalDateTime(calendarEvent.Start);
                evt.End = new iCalDateTime(calendarEvent.End);
                evt.Description = calendarEvent.Description;
                evt.Location = calendarEvent.Location;
                evt.Summary = calendarEvent.Summary;
            }

            var bytes = Serialize(iCal);
            await response.Body.WriteAsync(bytes, 0, bytes.Length, cancellation);
        }

        private static byte[] Serialize(iCalendar iCal)
        {
            var context = new SerializationContext();
            var factory = new SerializerFactory();
            var serializer = (IStringSerializer) factory.Build(iCal.GetType(), context);
            var output = serializer.SerializeToString(iCal);
            return Encoding.UTF8.GetBytes(output);
        }
    }
}