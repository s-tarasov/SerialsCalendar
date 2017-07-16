using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TMDbLib.Client;
using TMDbLib.Objects.TvShows;

namespace Calendar.Builder.ReleaseProviders.TMD
{
    public class TMDReleaseProvider : ReleaseProviderBase
    {
        private readonly ISerialIdProvider _serialIdProvider;
        private readonly TMDbClient _client;
        private readonly DateTime _minDate;
        private readonly DateTime _minSeasonAirDate;

        public TMDReleaseProvider(ISerialIdProvider serialIdProvider, TMDbClient client, DateTime minDate)
        {
            _serialIdProvider = serialIdProvider;
            _client = client;
            _minDate = minDate;
            _minSeasonAirDate = minDate.AddMonths(-6);
        }

        private DateTime CorrectTimezoneOffset(DateTime originalDate)
        {
            return originalDate.AddDays(1);
        }

        protected override async Task<IEnumerable<ReleaseEvent>> GetSerialReleasesAsync(string serialAlias)
        {
            var serialId = await _serialIdProvider.GetSerialId(serialAlias);
            if (serialId == null)
            {
                return Enumerable.Empty<ReleaseEvent>();
            }

            var events = new List<ReleaseEvent>();
            var movie = await _client.GetTvShowAsync(int.Parse(serialId));
            foreach (var season in movie.Seasons.Where(s => s.SeasonNumber > 0 && s.AirDate > _minSeasonAirDate))
            {
                var tvSeason = await _client.GetTvSeasonAsync(movie.Id, season.SeasonNumber);
                events.AddRange(ToReleaseEvents(tvSeason, movie.Name));
            }

            return events;
        }

        private IEnumerable<ReleaseEvent> ToReleaseEvents(TvSeason tvSeason, string movieName)
        {
            foreach (var episode in tvSeason.Episodes)
            {
                if (episode.AirDate > _minDate)
                {
                    yield return new ReleaseEvent(
                        episode.AirDate.Value,
                        movieName + " " + string.Format("S{0}E{1}", episode.SeasonNumber, episode.EpisodeNumber),
                        episode.Name
                   );
                }
            }
        }
    }
}
