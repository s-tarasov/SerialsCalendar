using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SerialsCalendar
{
    public class TvRageComSerialsDateRuReleaseEventsProvider : ReleaseEventsProviderBase
    {
        private readonly string _apiKey;
        private readonly HttpClient _client;
        private readonly DateTime _minDate;

        public TvRageComSerialsDateRuReleaseEventsProvider(string apiKey, HttpClient client, DateTime minDate)
        {
            _apiKey = apiKey;
            _client = client;
            _minDate = minDate;
        }

        private DateTime CorrectTimezoneOffset(DateTime originalDate)
        {
            return originalDate.AddDays(1);
        }

        protected override async Task<IEnumerable<ReleaseEvent>> GetSerialReleasesAsync(string serialAlias)
        {
            var serialId = (await _client.GetStringAsync("http://services.tvrage.com/feeds/search.php?key=" + _apiKey + "&show=" + serialAlias))
                .AsXDocument()
                .XPathSelectElement("//show//showid")
                .Value;

            var xml = (await _client.GetStringAsync("http://services.tvrage.com/feeds/episode_list.php?key=" + _apiKey + "&sid=" + serialId))
                .AsXDocument();
            var serialName = xml.XPathSelectElement("/Show/name").Value;

            return xml
                .XPathSelectElements("//Episodelist//Season//episode")
                .Select(episodeNode => new ReleaseEvent(
                            date: CorrectTimezoneOffset(DateTime.Parse(episodeNode.XPathSelectElement("airdate").Value)),
                            summary: serialName + " " + string.Format(
                                "S{0}E{1}",
                                episodeNode.Parent.Attribute("no").Value,
                                episodeNode.XPathSelectElement("seasonnum").Value
                            )))
                .Where(r => r.Date > _minDate)
                .ToArray();
        }
    }
}
