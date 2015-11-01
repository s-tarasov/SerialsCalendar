using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TMDbLib.Client;

namespace Calendar.Builder.ReleaseProviders.TMD
{
    public class TMDReleaseProvider : ReleaseProviderBase
    {
        private readonly ISerialIdProvider _serialIdProvider;
        private readonly TMDbClient _client;
        private readonly DateTime _minDate;

        public TMDReleaseProvider(ISerialIdProvider serialIdProvider, TMDbClient client, DateTime minDate)
        {
            _serialIdProvider = serialIdProvider;
            _client = client;
            _minDate = minDate;
        }

        private DateTime CorrectTimezoneOffset(DateTime originalDate)
        {
            return originalDate.AddDays(1);
        }

        protected override async Task<IEnumerable<ReleaseEvent>> GetSerialReleasesAsync(string serialAlias)
        {
            var serialId = await _serialIdProvider.GetSerialId(serialAlias);
            if (serialId == null) {
                return Enumerable.Empty<ReleaseEvent>();
            }

            return GetSerialReleases(int.Parse(serialId));
        }

        private IEnumerable<ReleaseEvent> GetSerialReleases(int serialId)
        {
            var movie = _client.GetTvShow(serialId);

            foreach (var season in movie.Seasons.Where(s => s.SeasonNumber > 0))
            {
                var tvSeason = _client.GetTvSeason(movie.Id, season.SeasonNumber);

                foreach (var episode in tvSeason.Episodes)
                {
                    yield return new ReleaseEvent(
                        episode.AirDate,
                        movie.Name + " " + string.Format("S{0}E{1}", episode.SeasonNumber, episode.EpisodeNumber),
                        episode.Name
                    );
                }
            }
        }

    }
}
