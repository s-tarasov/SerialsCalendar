using System.Collections.Generic;
using System.Diagnostics;

using Calendar.Common.Extensions;
using Calendar.CQRS;

namespace Calendar.Domain.Users
{
    public class GetUserSerials : IQuery<IEnumerable<GetUserSerials.Serial>>
    {
        #region NestedTypes
        public class Serial {
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
            public string TvRangeId { get; set; }

            public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        }
        #endregion


        public GetUserSerials(string userId)
        {
            Debug.Assert(!userId.IsNullOrEmpty());

            UserId = userId;
        }

        public string UserId { get; }
    }
}