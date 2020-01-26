using System;

namespace Calendar.Builder
{
    public interface ICalendarEvent
    {
        DateTime Start { get; }

        DateTime End { get; }

        string Description { get; }

        string Summary { get; }

        string? Location { get; }
    }
}