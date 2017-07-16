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
            public string TvRangeId { get; set; }

            public string Title { get; set; }
        }
        #endregion

        private readonly string _userId;

        public GetUserSerials(string userId)
        {
            Debug.Assert(!userId.IsNullOrEmpty());

            _userId = userId;
        }

        public string UserId
        {
            get
            {
                return _userId;
            }
        }
    }
}