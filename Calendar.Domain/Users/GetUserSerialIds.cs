using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Calendar.Common.Extensions;
using Calendar.CQRS;

namespace Calendar.Domain.Users
{
    public class GetUserSerialIds : IQuery<IEnumerable<string>>
    {
        private readonly string _userId;

        public GetUserSerialIds(string userId)
        {
            Contract.Requires(!userId.IsNullOrEmpty());

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