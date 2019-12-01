using System.Diagnostics;

using Calendar.Common.Extensions;
using Calendar.CQRS;

namespace Calendar.Domain.Users
{
    public class GetUserSerialIds : IQuery<string[]>
    {
        public GetUserSerialIds(string userId)
        {
            Debug.Assert(!userId.IsNullOrEmpty());

            UserId = userId;
        }

        public string UserId { get; }
    }
}