using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

using Calendar.CQRS;
using Calendar.Domain.Users;
using Calendar.Builder.ReleaseProviders.TMD;

namespace Calendar.Data.Implementation.Users
{
    public class GetUserSerialsHandler : IQueryHandler<GetUserSerials, IEnumerable<GetUserSerials.Serial>>
    {
        private readonly IDataDispatcher _dataDispather;
        private readonly ISerialIdProvider _serialIdProvider;

        public GetUserSerialsHandler(
            IDataDispatcher dataDispather, 
            ISerialIdProvider serialIdProvider)
        {
            Contract.Requires(dataDispather != null);
            Contract.Requires(serialIdProvider != null);

            _dataDispather = dataDispather;
            _serialIdProvider = serialIdProvider;
        }

        public async Task<IEnumerable<GetUserSerials.Serial>> HandleAsync(GetUserSerials query)
        {
            var serialIds = await _dataDispather.ExecuteAsync(new GetUserSerialIds(query.UserId));

            return await Task.WhenAll(
                    serialIds
                        .Select(async s => new GetUserSerials.Serial {
                            Title = s,
                            TvRangeId = await _serialIdProvider.GetSerialId(s)
                        })
                        .ToArray()
                );
        }
    }
}
