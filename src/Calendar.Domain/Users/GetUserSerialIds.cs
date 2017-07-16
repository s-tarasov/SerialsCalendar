using System.Collections.Generic;
using System.Diagnostics;

using Calendar.Common.Extensions;
using Calendar.CQRS;

namespace Calendar.Domain.Users
{
    public class GetUserSerialIds : IQuery<IEnumerable<string>>
    {
        private readonly string _userId;

        public GetUserSerialIds(string userId)
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