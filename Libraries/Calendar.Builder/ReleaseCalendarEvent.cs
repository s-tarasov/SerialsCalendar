using System;
using System.Diagnostics.Contracts;

using Calendar.Builder.ReleaseProviders;

namespace Calendar.Builder
{
    public class ReleaseCalendarEvent : ICalendarEvent
    {
        private readonly ReleaseEvent _release;

        public ReleaseCalendarEvent(ReleaseEvent release)
        {
            Contract.Requires(release != null);

            _release = release;
        }

        public DateTime Start
        {
            get { return _release.Date; }
        }

        public DateTime End
        {
            get { return _release.Date.AddDays(1); }
        }

        public string Description
        {
            get { return _release.Description; }
        }

        public string Summary
        {
            get { return _release.Summary; }
        }

        public string Location
        {
            get { return null; }
        }
    }
}
