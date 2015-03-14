using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CalendarCore
{
    public class TvRageComReleaseEventsProvider : ReleaseEventsProviderBase
    {
        private readonly string _apiKey;
        private readonly HttpClient _client;
        private readonly DateTime _minDate;
        private readonly ISerialIdProvider _serialIdProvider;

        public TvRageComReleaseEventsProvider(string apiKey, HttpClient client, DateTime minDate, ISerialIdProvider serialIdProvider)
        {
            _apiKey = apiKey;
            _client = client;
            _minDate = minDate;
            _serialIdProvider = serialIdProvider;
        }

        private DateTime CorrectTimezoneOffset(DateTime originalDate)
        {
            return originalDate.AddDays(1);
        }

        private static DateTime SafeDateParse(string dateSource)
        {
            DateTime date;
            if (DateTime.TryParse(dateSource, out date))
            {
                return date;
            }

            return DateTime.MinValue;
        }

        protected override async Task<IEnumerable<ReleaseEvent>> GetSerialReleasesAsync(string serialAlias)
        {
            var serialId = await _serialIdProvider.GetSerialId(serialAlias);

            var xml = (await _client.GetStringAsync("http://services.tvrage.com/feeds/episode_list.php?key=" + _apiKey + "&sid=" + serialId))
                .AsXDocument();
            var serialName = xml.XPathSelectElement("/Show/name").Value;

            return xml
                .XPathSelectElements("//Episodelist//Season//episode")
                .Select(episodeNode => new ReleaseEvent(
                            date: CorrectTimezoneOffset(SafeDateParse(episodeNode.XPathSelectElement("airdate").Value)),
                            summary: serialName + " " + string.Format(
                                "S{0}E{1}",
                                episodeNode.Parent.Attribute("no").Value,
                                episodeNode.XPathSelectElement("seasonnum").Value
                            ),
                            description: episodeNode.XPathSelectElement("title").Value))
                .Where(r => r.Date > _minDate)
                .ToArray();
        }

    }
}
