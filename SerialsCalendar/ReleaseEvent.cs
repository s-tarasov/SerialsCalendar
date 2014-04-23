using System;

namespace SerialsCalendar
{
    public class ReleaseEvent
    {
        private readonly DateTime _date;
        private readonly string _summary;

        public ReleaseEvent(DateTime date, string summary)
        {
            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentException("summary");
            }

            if (date == DateTime.MinValue)
            {
                throw new ArgumentException("date");
            }

            _date = date;
            _summary = summary;
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public string Summary
        {
            get { return _summary; }
        }


        public bool Same(CalendarEvent @event)
        {
            return @event.Date == Date 
                && @event.Summary == Summary;
        }
    }
}