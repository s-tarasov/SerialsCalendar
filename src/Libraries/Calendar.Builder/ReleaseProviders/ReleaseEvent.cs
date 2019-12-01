using System;

namespace Calendar.Builder.ReleaseProviders
{
    public class ReleaseEvent
    {
        public ReleaseEvent(DateTime date, string summary, string description)
        {
            if (string.IsNullOrWhiteSpace(summary))
            {
                throw new ArgumentException("summary");
            }

            if (date == default)
            {
                throw new ArgumentException("date");
            }

            Date = date;
            Summary = summary;
            Description = description;            
        }

        public DateTime Date { get; }

        public string Summary { get; }

        public string Description { get; }
    }
}