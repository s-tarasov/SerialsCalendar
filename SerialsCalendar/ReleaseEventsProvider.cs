using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SerialsCalendar
{
    public class ReleaseEventsProvider
    {
        private readonly HttpClient _client;
        private readonly DateTime _minDate;

        public ReleaseEventsProvider(HttpClient client, DateTime minDate)
        {
            _client = client;
            _minDate = minDate;
        }

        public async Task<IEnumerable<ReleaseEvent>> GetSerialReleasesAsync(string serialId)
        {
            var htmlDocument = LoadHtml(await _client.GetStringAsync("http://www.serialdate.ru/serial.php?id=" + serialId));
            var serialName = htmlDocument.SelectSingleNode("//h1").InnerText.Split('/').First().Trim();
            return htmlDocument
                .SelectNodes("//table[@class='dates']//tr")
                .Select(row =>
                {
                    var cells = LoadHtml(row.OuterHtml).SelectNodes("//td");
                    var dateParts = cells[0].InnerText
                        .Split('.')
                        .Select(int.Parse)
                        .ToList();

                    if (dateParts.Count == 2)
                    {
                        dateParts.Add(DateTime.Today.Year);
                    }

                    return new ReleaseEvent(
                        date: new DateTime(dateParts[2], dateParts[1], dateParts[0]),
                        summary: serialName + " " + WebUtility.HtmlDecode(cells[1].InnerText));
                })
                .Where(r => r.Date > _minDate)
                .ToArray();
        }

        public async Task<IEnumerable<ReleaseEvent>> GetReleasesAsync(IEnumerable<string> serialIds)
        {
            var releases = await serialIds
                    .Select(GetSerialReleasesAsync)
                    .WhenAll();

            return releases.SelectMany(r => r).ToArray();
        }

        HtmlNode LoadHtml(string html)
        {
            var d = new HtmlDocument();
            d.LoadHtml(html);
            return d.DocumentNode;
        }
    }
}
