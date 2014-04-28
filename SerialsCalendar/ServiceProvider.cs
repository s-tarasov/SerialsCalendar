using System;
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

        public ReleaseEventsProviderBase GetReleaseEventsProvider()
        {
            var apiKey = ConfigurationManager.AppSettings["tvrangekey"];
            var client = new HttpClient();
            var idProvider = new TvRageComSerialIdProvider(apiKey, client);
            var cachedIdProvider = new CachedSerialIdProvider(idProvider, new FileSystemCache("Serialids"));

            return new TvRageComReleaseEventsProvider(apiKey, client, DateTime.Today.AddYears(-1), cachedIdProvider);
        }

        private async Task<CalendarService> CreateCalendarServiceAsync()
        {
            var serviceInizializer = await GoogleApiServiceInizializerFactory.GetServiceInizializerAsync(
                clientId: ConfigurationManager.AppSettings["clientId"],
                clientSecret: ConfigurationManager.AppSettings["clientSecret"]);

            return new CalendarService(serviceInizializer);
        }

        public void Dispose()
        {
            
        }
    }
}