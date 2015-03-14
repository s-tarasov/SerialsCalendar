using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CalendarCore
{
    public class TvRageComSerialIdProvider : ISerialIdProvider
    {
        private readonly string _apiKey;
        private readonly HttpClient _client;

        public TvRageComSerialIdProvider(string apiKey, HttpClient client)
        {
            _apiKey = apiKey;
            _client = client;
        }

        public async Task<string> GetSerialId(string serialAlias)
        {
            return (await
                _client.GetStringAsync("http://services.tvrage.com/feeds/search.php?key=" + _apiKey + "&show=" + serialAlias))
                .AsXDocument()
                .XPathSelectElement("//show//showid")
                .Value;
        }
    }
}