using System;

namespace SerialsCalendar
{
    public class ReleaseEvent
    {
        private readonly DateTime _date;
        private readonly string _summary;
        private readonly string _description;

        public ReleaseEvent(DateTime date, string summary, string description)
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
            _description = description;
            
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public string Summary
        {
            get { return _summary; }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}