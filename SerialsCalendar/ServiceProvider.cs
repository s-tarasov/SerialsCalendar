using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3;

namespace SerialsCalendar
{
    public class ServiceProvider : IDisposable
    {
        public CalendarUpdater GetCalendarUpdater()
        {
            var calendar = new Calendar(CreateCalendarServiceAsync(), ConfigurationManager.AppSettings["calendarId"]);

            return new CalendarUpdater(calendar);
        }

        public ReleaseEventsProvider GetReleaseEventsProvider()
        {
            return new ReleaseEventsProvider(new HttpClient(), DateTime.Today.AddYears(-1));
        }

        private async Task<CalendarService> CreateCalendarServiceAsync()
        {
            var serviceInizializer = await ServiceInizializerFactory.GetServiceInizializerAsync(
                clientId: ConfigurationManager.AppSettings["clientId"],
                clientSecret: ConfigurationManager.AppSettings["clientSecret"]);

            return new CalendarService(serviceInizializer);
        }

        public void Dispose()
        {
            
        }
    }
}