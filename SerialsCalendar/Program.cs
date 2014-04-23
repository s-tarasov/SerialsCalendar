using System.Configuration;
using System.Threading.Tasks;

namespace SerialsCalendar
{
    class Program
    {
        static void Main(string[] args)
        {

#if DEBUG
            UnsafeMainAsync(args).Wait();
#else
            log4net.Config.XmlConfigurator.Configure();
            var log = log4net.LogManager.GetLogger("default");
            try
            {
                UnsafeMainAsync(args).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    log.Fatal(e);
                }
            }
            catch (Exception e){
                log.Fatal(e);
            }
#endif
        }

        private static async Task UnsafeMainAsync(string[] args)
        {
            var serialIds = ConfigurationManager.AppSettings["serialIds"].Split(',');

            using (var serviceProvider = new ServiceProvider())
            {
                var provider = serviceProvider.GetReleaseEventsProvider();
                var updater = serviceProvider.GetCalendarUpdater();
                await updater.UpdateCalendarAsync(provider.GetReleasesAsync(serialIds));
            }
        }
    }
}
