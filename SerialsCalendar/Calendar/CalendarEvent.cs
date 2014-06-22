using System;
using Google.Apis.Calendar.v3.Data;

namespace SerialsCalendar
{
    public class CalendarEvent
    {
        private readonly Event _internalEvent;

        public CalendarEvent(Event internalEvent)
        {
            _internalEvent = internalEvent;
        }

        public string Id
        {
            get { return _internalEvent.Id; }
        }

        public string Summary
        {
            get { return _internalEvent.Summary; }
        }

        public DateTime Date
        {
            get { return DateTime.Parse(_internalEvent.Start.Date); }
        }

        public string Description
        {
            get { return _internalEvent.Description; }
        }
    }
}